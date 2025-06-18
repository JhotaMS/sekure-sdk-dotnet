using Newtonsoft.Json;
using Sekure.Models;
using Sekure.Models.RiskValidator;
using Sekure.Security;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sekure.Runtime;

public class InsuranceOS : IInsuranceOS
{
    private readonly string apiUrl = string.Empty;
    private readonly string apiKey = string.Empty;
    private readonly string clientIpAddress = string.Empty;
    private readonly EncryptionService _encryptionService;
    private readonly bool _useEncryption;
    private readonly HttpClient _client;

    public InsuranceOS(
        string apiUrl
        , string apiKey
        , HttpClient client
        , bool useEncryption = false
        , string encryptionKey = null
        , string encryptionIv = null
    )
    {
        this.apiUrl = apiUrl;
        this.apiKey = apiKey;

        _client = client;
        _useEncryption = useEncryption;

        if (_useEncryption)
        {
            _encryptionService = new EncryptionService(encryptionKey, encryptionIv);
        }
    }

    public InsuranceOS(
        string apiUrl
        , string apiKey
        , string clientIpAddress
        , HttpClient client
        , bool useEncryption = false
        , string encryptionKey = null
        , string encryptionIv = null
    )
    {
        this.apiUrl = apiUrl;
        this.apiKey = apiKey;
        this.clientIpAddress = clientIpAddress;

        _client = client;
        _useEncryption = useEncryption;

        if (_useEncryption)
        {
            _encryptionService = new EncryptionService(encryptionKey, encryptionIv);
        }
    }

    public InsuranceOS(
        string apiUrl
        , string apiKey
        , string clientIpAddress
        , HttpClient client
    )
    {
        this.apiUrl = apiUrl;
        this.apiKey = apiKey;
        this.clientIpAddress = clientIpAddress;
        _client = client;
    }

    private HttpClient GetClient()
    {
        _client.DefaultRequestHeaders.Add("skr-key", apiKey);
        _client.DefaultRequestHeaders.Add("client-ip-address", clientIpAddress);
        return _client;
    }

    #region Product

    public async Task<List<ProductReference>> GetProducts()
    {
        HttpResponseMessage response = await
            GetClient()
            .GetAsync($"{apiUrl}/Products");

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(
                $"statusCode: {response.StatusCode}, messageException: {response.Content.ReadAsStringAsync().Result}"
            );
        }

        string productsJson = await response.Content.ReadAsStringAsync();


        List<ProductReference> products = _useEncryption
            ? JsonConvert.DeserializeObject<List<ProductReference>>(productsJson, new EncryptedJsonConverter<QuotedProduct>(_encryptionService, false))
            : JsonConvert.DeserializeObject<List<ProductReference>>(productsJson, new JsonSerializerSettings
            { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore });

        return products;
    }

    [Obsolete("This property is obsolete. Use ProductByIdNoPolicyHolder instead.", false)]
    public async Task<Product> GetProductById(int id)
    {
        HttpResponseMessage response = await GetClient().GetAsync($"{apiUrl}/Products/{id}");

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"statusCode: {response.StatusCode}, messageException: {response.Content.ReadAsStringAsync().Result}");
        }

        string productResponseJson = await response.Content.ReadAsStringAsync();

        Product product = _useEncryption
            ? JsonConvert.DeserializeObject<Product>(productResponseJson, new EncryptedJsonConverter<QuotedProduct>(_encryptionService, false))
            : JsonConvert.DeserializeObject<Product>(productResponseJson, new JsonSerializerSettings
            { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore });

        return product;
    }

    public async Task<Product> ProductByIdNoPolicyHolder(int id)
    {
        HttpResponseMessage response = await GetClient().GetAsync($"{apiUrl}/v1/Products/{id}");

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"statusCode: {response.StatusCode}, messageException: {response.Content.ReadAsStringAsync().Result}");
        }
        string productResponseJson = await response.Content.ReadAsStringAsync();

        Product product = _useEncryption
            ? JsonConvert.DeserializeObject<Product>(productResponseJson, new EncryptedJsonConverter<QuotedProduct>(_encryptionService, false))
            : JsonConvert.DeserializeObject<Product>(productResponseJson, new JsonSerializerSettings
            { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore });

        return product;
    }

    public async Task<QuotedProduct> Quote(ExecutableProduct executableProduct)
    {
        string jsonProduct = _useEncryption
            ? JsonConvert.SerializeObject(executableProduct, new EncryptedJsonConverter<ExecutableProduct>(_encryptionService, true))
            : JsonConvert.SerializeObject(executableProduct);

        HttpResponseMessage response = await GetClient().PostAsync($"{apiUrl}/Products/Quote", new StringContent(jsonProduct, Encoding.UTF8, "application/json"));

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"statusCode: {response.StatusCode}, messageException: {response.Content.ReadAsStringAsync().Result}");
        }

        string quotedProductJson = await response.Content.ReadAsStringAsync();

        QuotedProduct quotedProduct = _useEncryption
            ? JsonConvert.DeserializeObject<QuotedProduct>(quotedProductJson, new EncryptedJsonConverter<QuotedProduct>(_encryptionService, false))
            : JsonConvert.DeserializeObject<QuotedProduct>(quotedProductJson, new JsonSerializerSettings
            { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore });

        return quotedProduct;
    }

    public async Task<Policy> Confirm(ExecutableProduct executableProduct, Guid sessionId)
    {
        string jsonProduct = _useEncryption
            ? JsonConvert.SerializeObject(executableProduct, new EncryptedJsonConverter<ExecutableProduct>(_encryptionService, true))
            : JsonConvert.SerializeObject(executableProduct);

        HttpResponseMessage response = await GetClient().PostAsync($"{apiUrl}/Products/Confirm/{sessionId}", new StringContent(jsonProduct, Encoding.UTF8, "application/json"));

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"statusCode: {response.StatusCode}, messageException: {response.Content.ReadAsStringAsync().Result}");
        }

        string confirmedProductJson = await response.Content.ReadAsStringAsync();

        Policy policy = _useEncryption
            ? JsonConvert.DeserializeObject<Policy>(confirmedProductJson, new EncryptedJsonConverter<QuotedProduct>(_encryptionService, false))
            : JsonConvert.DeserializeObject<Policy>(confirmedProductJson, new JsonSerializerSettings
            { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore });

        return policy;
    }

    [Obsolete("This property is obsolete. Use EmitWithPolicy instead.", false)]
    public async Task<string> Emit(ExecutableProduct executableProduct, Guid sessionId)
    {
        string jsonProduct = _useEncryption
            ? JsonConvert.SerializeObject(executableProduct, new EncryptedJsonConverter<ExecutableProduct>(_encryptionService, true))
            : JsonConvert.SerializeObject(executableProduct);

        HttpResponseMessage response = await GetClient().PostAsync($"{apiUrl}/Products/Emit/{sessionId}", new StringContent(jsonProduct, Encoding.UTF8, "application/json"));

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"statusCode: {response.StatusCode}, messageException: {response.Content.ReadAsStringAsync().Result}");
        }

        string stage = await response.Content.ReadAsStringAsync();

        return stage;
    }

    public async Task<Policy> EmitWithPolicy(ExecutableProduct executableProduct, Guid sessionId)
    {
        string jsonProduct = _useEncryption
            ? JsonConvert.SerializeObject(executableProduct, new EncryptedJsonConverter<ExecutableProduct>(_encryptionService, true))
            : JsonConvert.SerializeObject(executableProduct);

        HttpResponseMessage response = await GetClient().PostAsync($"{apiUrl}/v1/Products/Emit/{sessionId}", new StringContent(jsonProduct, Encoding.UTF8, "application/json"));

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"statusCode: {response.StatusCode}, messageException: {response.Content.ReadAsStringAsync().Result}");
        }

        string emitProductJson = await response.Content.ReadAsStringAsync();

        Policy policy = _useEncryption
            ? JsonConvert.DeserializeObject<Policy>(emitProductJson, new EncryptedJsonConverter<QuotedProduct>(_encryptionService, false))
            : JsonConvert.DeserializeObject<Policy>(emitProductJson, new JsonSerializerSettings
            { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore });

        return policy;
    }

    public async Task<string> Cancel(Guid sessionId)
    {
        var request = new HttpRequestMessage(new HttpMethod("PATCH"), $"{apiUrl}/Products/Cancel/{sessionId}");
        HttpResponseMessage response = await GetClient().SendAsync(request);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"statusCode: {response.StatusCode}, messageException: {response.Content.ReadAsStringAsync().Result}");
        }

        string result = await response.Content.ReadAsStringAsync();

        return result;
    }

    public async Task<ProductStage> GetProductStage(Guid sessionId)
    {
        HttpResponseMessage response = await GetClient().GetAsync($"{apiUrl}/Products/Stage/{sessionId}");

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"statusCode: {response.StatusCode}, messageException: {response.Content.ReadAsStringAsync().Result}");
        }

        string productStageJson = await response.Content.ReadAsStringAsync();
        ProductStage productStage = JsonConvert.DeserializeObject<ProductStage>(productStageJson, new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore
        });

        return productStage;
    }

    public async Task<Policy> GetProductDetailsBySessionId(Guid sessionId)
    {
        var response = await GetClient().GetAsync($"{apiUrl}/Product/Details/{sessionId}");
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"statusCode: {response.StatusCode}, messageException: {response.Content.ReadAsStringAsync().Result}");
        }

        string policyJson = await response.Content.ReadAsStringAsync();

        Policy policy = _useEncryption
            ? JsonConvert.DeserializeObject<Policy>(policyJson, new EncryptedJsonConverter<QuotedProduct>(_encryptionService, false))
            : JsonConvert.DeserializeObject<Policy>(policyJson, new JsonSerializerSettings
            { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore });

        return policy;
    }

    #endregion

    #region ProductLot
    public async Task<BatchDiscovery> GetProductLotByName(string name)
    {
        HttpResponseMessage response = await GetClient().GetAsync($"{apiUrl}/Products/Batch/{name}");

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"statusCode: {response.StatusCode}, messageException: {response.Content.ReadAsStringAsync().Result}");
        }

        string productResponseJson = await response.Content.ReadAsStringAsync();
        BatchDiscovery lot = JsonConvert.DeserializeObject<BatchDiscovery>(productResponseJson, new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore
        });

        return lot;
    }

    public async Task<QuotedProductLot> Quote(ExecutatbleProductLot executatbleProductLot)
    {
        string jsonProduct = JsonConvert.SerializeObject(executatbleProductLot);

        HttpResponseMessage response = await GetClient().PostAsync($"{apiUrl}/Products/Batch/Quote", new StringContent(jsonProduct, Encoding.UTF8, "application/json"));

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"statusCode: {response.StatusCode}, messageException: {response.Content.ReadAsStringAsync().Result}");
        }

        string quotedProductJson = await response.Content.ReadAsStringAsync();
        QuotedProductLot quotedProduct = JsonConvert.DeserializeObject<QuotedProductLot>(quotedProductJson, new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore
        });

        return quotedProduct;
    }

    public async Task<Policy> Confirm(ExecutatbleProductLot executableProduct, Guid sessionId)
    {
        string jsonProduct = JsonConvert.SerializeObject(executableProduct);

        HttpResponseMessage response = await GetClient().PostAsync($"{apiUrl}/Products/Batch/Confirm/{sessionId}", new StringContent(jsonProduct, Encoding.UTF8, "application/json"));

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"statusCode: {response.StatusCode}, messageException: {response.Content.ReadAsStringAsync().Result}");
        }

        string confirmedProductJson = await response.Content.ReadAsStringAsync();
        Policy policy = JsonConvert.DeserializeObject<Policy>(confirmedProductJson, new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore
        });

        return policy;
    }

    public async Task<Policy> EmitWithPolicy(ExecutatbleProductLot executableProduct, Guid sessionId)
    {
        string jsonProduct = JsonConvert.SerializeObject(executableProduct);

        HttpResponseMessage response = await GetClient().PostAsync($"{apiUrl}/Products/Batch/Emit/{sessionId}", new StringContent(jsonProduct, Encoding.UTF8, "application/json"));

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"statusCode: {response.StatusCode}, messageException: {response.Content.ReadAsStringAsync().Result}");
        }

        string result = await response.Content.ReadAsStringAsync();
        Policy policy = JsonConvert.DeserializeObject<Policy>(result, new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore
        });

        return policy;
    }
    #endregion

    #region Estimate
    public async Task<Estimate> GetEstimateBySessionId(Guid sessionId)
    {
        HttpResponseMessage response = await GetClient().GetAsync($"{apiUrl}/Estimates/Session/{sessionId}");

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"statusCode: {response.StatusCode}, messageException: {response.Content.ReadAsStringAsync().Result}");
        }

        string estimateBySessionIdJson = await response.Content.ReadAsStringAsync();
        Estimate estimate = JsonConvert.DeserializeObject<Estimate>(estimateBySessionIdJson, new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore
        });

        return estimate;
    }

    public async Task<QuotedProduct> GetQuoteBySessionId(Guid sessionId)
    {
        HttpResponseMessage response = await GetClient().GetAsync($"{apiUrl}/Quote/Session/{sessionId}");

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"statusCode: {response.StatusCode}, messageException: {response.Content.ReadAsStringAsync().Result}");
        }

        string estimateBySessionIdJson = await response.Content.ReadAsStringAsync();
        Estimate estimate = JsonConvert.DeserializeObject<Estimate>(estimateBySessionIdJson);

        QuotedProduct quotedProduct = JsonConvert.DeserializeObject<QuotedProduct>(estimate.Response, new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore
        });

        return quotedProduct;
    }

    #endregion

    #region Payment

    public async Task<string> Pay(PaymentDetail paymentDetail)
    {
        string jsonPaymentDetail = JsonConvert.SerializeObject(paymentDetail);

        HttpResponseMessage response = await GetClient().PostAsync($"{apiUrl}/Payment", new StringContent(jsonPaymentDetail, Encoding.UTF8, "application/json"));

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"statusCode: {response.StatusCode}, messageException: {response.Content.ReadAsStringAsync().Result}");
        }

        string responsePayment = await response.Content.ReadAsStringAsync();

        return responsePayment;
    }

    public async Task<string> SessionToken(PaymentDetail paymentDetail)
    {
        string jsonPaymentDetail = JsonConvert.SerializeObject(paymentDetail);

        HttpResponseMessage response = await GetClient().PostAsync($"{apiUrl}/SessionToken", new StringContent(jsonPaymentDetail, Encoding.UTF8, "application/json"));

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"statusCode: {response.StatusCode}, messageException: {response.Content.ReadAsStringAsync().Result}");
        }

        string responsePayment = await response.Content.ReadAsStringAsync();

        return responsePayment;
    }

    public async Task<string> ReverseCapture(PaymentDetail paymentDetail)
    {
        string jsonPaymentDetail = JsonConvert.SerializeObject(paymentDetail);

        HttpResponseMessage response = await GetClient().PostAsync($"{apiUrl}/ReverseCapture", new StringContent(jsonPaymentDetail, Encoding.UTF8, "application/json"));

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"statusCode: {response.StatusCode}, messageException: {response.Content.ReadAsStringAsync().Result}");
        }

        string responsePayment = await response.Content.ReadAsStringAsync();

        return responsePayment;
    }

    public async Task<PaymentStatus> GetTokenizationStatus(PaymentDetail paymentDetail)
    {
        string jsonPaymentDetail = JsonConvert.SerializeObject(paymentDetail);

        HttpResponseMessage response = await GetClient().PostAsync($"{apiUrl}/Payment/TokenizationStatus", new StringContent(jsonPaymentDetail, Encoding.UTF8, "application/json"));

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"statusCode: {response.StatusCode}, messageException: {response.Content.ReadAsStringAsync().Result}");
        }

        string statusJson = await response.Content.ReadAsStringAsync();
        PaymentStatus paymentStatus = JsonConvert.DeserializeObject<PaymentStatus>(statusJson);

        return paymentStatus;
    }

    public async Task<PaymentStatus> GetPaymentStatus(PaymentDetail paymentDetail)
    {
        string jsonPaymentDetail = JsonConvert.SerializeObject(paymentDetail);

        HttpResponseMessage response = await GetClient().PostAsync($"{apiUrl}/Payment/Status", new StringContent(jsonPaymentDetail, Encoding.UTF8, "application/json"));

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"statusCode: {response.StatusCode}, messageException: {response.Content.ReadAsStringAsync().Result}");
        }

        string statusJson = await response.Content.ReadAsStringAsync();
        PaymentStatus paymentStatus = JsonConvert.DeserializeObject<PaymentStatus>(statusJson, new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore
        });

        return paymentStatus;
    }

    public async Task<PaymentGatewayProduct> GetPaymentGatewayConfiguration(string paymentGatewayName, string productName)
    {
        HttpResponseMessage response = await GetClient().GetAsync($"{apiUrl}/Payment/Configuration/paymentGatewayName={paymentGatewayName}&productName={productName}");

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"statusCode: {response.StatusCode}, messageException: {response.Content.ReadAsStringAsync().Result}");
        }

        string pyamentGatewayProductJson = await response.Content.ReadAsStringAsync();
        PaymentGatewayProduct paymentGatewayProduct = JsonConvert.DeserializeObject<PaymentGatewayProduct>(pyamentGatewayProductJson, new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore
        });

        return paymentGatewayProduct;
    }

    public async Task<string> ConfirmPayment(PaymentDetail paymentDetail)
    {
        string jsonPaymentDetail = JsonConvert.SerializeObject(paymentDetail);
        HttpResponseMessage response = await GetClient().PostAsync($"{apiUrl}/ConfirmPayment", new StringContent(jsonPaymentDetail, Encoding.UTF8, "application/json"));

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"statusCode: {response.StatusCode}, messageException: {response.Content.ReadAsStringAsync().Result}");
        }

        string responsePayment = await response.Content.ReadAsStringAsync(); return responsePayment;
    }

    public async Task<string> UpdateSessionDetail(PaymentDetail paymentDetail)
    {
        string jsonPaymentDetail = JsonConvert.SerializeObject(paymentDetail);
        HttpResponseMessage response = await GetClient().PostAsync($"{apiUrl}/UpdateSessionDetail", new StringContent(jsonPaymentDetail, Encoding.UTF8, "application/json"));

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"statusCode: {response.StatusCode}, messageException: {response.Content.ReadAsStringAsync().Result}");
        }

        string responsePayment = await response.Content.ReadAsStringAsync();
        return responsePayment;
    }

    public async Task<string> SessionByNroElctronico(PaymentDetail paymentDetail)
    {
        string jsonPaymentDetail = JsonConvert.SerializeObject(paymentDetail);
        HttpResponseMessage response = await GetClient().PostAsync($"{apiUrl}/SessionByNroElctronico", new StringContent(jsonPaymentDetail, Encoding.UTF8, "application/json"));

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"statusCode: {response.StatusCode}, messageException: {response.Content.ReadAsStringAsync().Result}");
        }

        string responsePayment = await response.Content.ReadAsStringAsync();
        return responsePayment;
    }
    #endregion

    #region AskSekure
    public async Task<string> AskSekure(object parameters, int productId, string productName)
    {
        string jsonParameters = JsonConvert.SerializeObject(parameters);

        HttpResponseMessage response = await GetClient().PostAsync($"{apiUrl}/Products/AskSekure/productId={productId}&productName={productName}", new StringContent(jsonParameters, Encoding.UTF8, "application/json"));

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"statusCode: {response.StatusCode}, messageException: {response.Content.ReadAsStringAsync().Result}");
        }

        string responsePayment = await response.Content.ReadAsStringAsync();

        return responsePayment;
    }
    #endregion

    #region RiskValidation

    public async Task<ExecutableRiskValidator> RikValidator(RequestExecutable requestExecutable, Guid sessionId)
    {
        string jsonRequestExecutable = JsonConvert.SerializeObject(requestExecutable);
        HttpResponseMessage response = await GetClient().PostAsync($"{apiUrl}/risk/validator/{sessionId}", new StringContent(jsonRequestExecutable, Encoding.UTF8, "application/json"));
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"statusCode: {response.StatusCode}, messageException: {response.Content.ReadAsStringAsync().Result}");
        }
        string responseJson = await response.Content.ReadAsStringAsync();
        ExecutableRiskValidator executableRiskValidator = JsonConvert.DeserializeObject<ExecutableRiskValidator>(responseJson, new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore
        });
        return executableRiskValidator;
    }

    public async Task<ResponseConfiguration> GetValidatorConfiguration(Guid sessionId)
    {
        HttpResponseMessage response = await GetClient().GetAsync($"{apiUrl}/risk/getconfiguration/{sessionId}");

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"statusCode: {response.StatusCode}, messageException: {response.Content.ReadAsStringAsync().Result}");
        }

        string configurationJson = await response.Content.ReadAsStringAsync();

        ResponseConfiguration Configuration = JsonConvert.DeserializeObject<ResponseConfiguration>(configurationJson, new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore
        });

        return Configuration;
    }

    public async Task<ValidationProcess> ValidateStatus(RequestExecutable requestExecutable, Guid sessionId)
    {
        string jsonRequestExecutable = JsonConvert.SerializeObject(requestExecutable);
        HttpResponseMessage response = await GetClient().PostAsync($"{apiUrl}/SKR/ValidateStatus/{sessionId}", new StringContent(jsonRequestExecutable, Encoding.UTF8, "application/json"));
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"statusCode: {response.StatusCode}, messageException: {response.Content.ReadAsStringAsync().Result}");
        }
        string responseJson = await response.Content.ReadAsStringAsync();
        ValidationProcess executableRiskValidator = JsonConvert.DeserializeObject<ValidationProcess>(responseJson, new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore
        });
        return executableRiskValidator;
    }
    #endregion
}