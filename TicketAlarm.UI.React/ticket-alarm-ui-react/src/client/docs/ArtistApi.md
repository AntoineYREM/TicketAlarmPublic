# TicketAlarm.ArtistApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**apiArtistsGet**](ArtistApi.md#apiArtistsGet) | **GET** /api/artists | 
[**apiArtistsPost**](ArtistApi.md#apiArtistsPost) | **POST** /api/artists | 



## apiArtistsGet

> [ArtistDto] apiArtistsGet()



### Example

```javascript
import TicketAlarm from 'ticket_alarm';
let defaultClient = TicketAlarm.ApiClient.instance;
// Configure API key authorization: Bearer
let Bearer = defaultClient.authentications['Bearer'];
Bearer.apiKey = 'YOUR API KEY';
// Uncomment the following line to set a prefix for the API key, e.g. "Token" (defaults to null)
//Bearer.apiKeyPrefix = 'Token';

let apiInstance = new TicketAlarm.ArtistApi();
apiInstance.apiArtistsGet((error, data, response) => {
  if (error) {
    console.error(error);
  } else {
    console.log('API called successfully. Returned data: ' + data);
  }
});
```

### Parameters

This endpoint does not need any parameter.

### Return type

[**[ArtistDto]**](ArtistDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json


## apiArtistsPost

> Number apiArtistsPost(opts)



### Example

```javascript
import TicketAlarm from 'ticket_alarm';
let defaultClient = TicketAlarm.ApiClient.instance;
// Configure API key authorization: Bearer
let Bearer = defaultClient.authentications['Bearer'];
Bearer.apiKey = 'YOUR API KEY';
// Uncomment the following line to set a prefix for the API key, e.g. "Token" (defaults to null)
//Bearer.apiKeyPrefix = 'Token';

let apiInstance = new TicketAlarm.ArtistApi();
let opts = {
  'artistDto': new TicketAlarm.ArtistDto() // ArtistDto | 
};
apiInstance.apiArtistsPost(opts, (error, data, response) => {
  if (error) {
    console.error(error);
  } else {
    console.log('API called successfully. Returned data: ' + data);
  }
});
```

### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **artistDto** | [**ArtistDto**](ArtistDto.md)|  | [optional] 

### Return type

**Number**

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: application/json, text/json, application/*+json
- **Accept**: text/plain, application/json, text/json

