﻿using System.Net.Http.Json;
using WebApiITCrona.Context.Abstract.Context;
using WebApiITCrona.Context.Entity;
using WebApiITCrona.Models;
using WebApiITCrona.Repositories.Abstract;
using WebApiITCrona.Repositories.Implementations.Call;

namespace WebApiITCrona.Services;

/// <summary>
/// Сервис геолокации
/// </summary>
public class GeoService : IService
{
    private readonly IReadRepository<CallEntity> _readRepository;
    private readonly IWriteRepository<CallEntity> _writeRepository;
    private readonly IUnitOfWork unitOfWork;
    private readonly HttpClient _httpClient;

    private const string HttpClientName = "customHttpClient";

    /// <summary>
    /// ctor.
    /// </summary>
    public GeoService(
        IHttpClientFactory httpClientFactory,
        IReadRepository<CallEntity> readRepository,
        IWriteRepository<CallEntity> writeRepository,
        IUnitOfWork unitOfWork)
    {
        _readRepository = readRepository;
        _writeRepository = writeRepository;
        this.unitOfWork = unitOfWork;
        _httpClient = httpClientFactory.CreateClient(HttpClientName);
    }

    /// <inheritdoc/>
    public async Task<IpInfoResponse> GetInfoAboutIp(IpRequest ipRequest)
    {
        var entity = await _readRepository.GetEntityByIpAddress(ipRequest.Ip, CancellationToken.None);
        // проверить был ли такой IP
        if (entity is null)
        {
            // добавляем в БД
            _writeRepository.Add(new CallEntity(Guid.NewGuid(), ipRequest.Ip));
            await unitOfWork.SaveChangesAsync();
        }

        string requestUri = _httpClient.BaseAddress + ipRequest.Ip + "/geo";

        var response = await _httpClient.GetFromJsonAsync<IpInfoResponse>(requestUri);

        return response;
    }
}
