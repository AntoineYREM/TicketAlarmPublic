# TicketAlarm.ShowApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**apiShowsGet**](ShowApi.md#apiShowsGet) | **GET** /api/shows | 
[**apiShowsIdShowGet**](ShowApi.md#apiShowsIdShowGet) | **GET** /api/shows/{idShow} | 
[**apiShowsIdShowPut**](ShowApi.md#apiShowsIdShowPut) | **PUT** /api/shows/{idShow} | 
[**apiShowsPost**](ShowApi.md#apiShowsPost) | **POST** /api/shows | 



## apiShowsGet

> [ShowDto] apiShowsGet(opts)



### Example

```javascript
import TicketAlarm from 'ticket_alarm';
let defaultClient = TicketAlarm.ApiClient.instance;
// Configure API key authorization: Bearer
let Bearer = defaultClient.authentications['Bearer'];
Bearer.apiKey = 'YOUR API KEY';
// Uncomment the following line to set a prefix for the API key, e.g. "Token" (defaults to null)
//Bearer.apiKeyPrefix = 'Token';

let apiInstance = new TicketAlarm.ShowApi();
let opts = {
  'active': true, // Boolean | 
  'trending': false // Boolean | 
};
apiInstance.apiShowsGet(opts, (error, data, response) => {
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
 **active** | **Boolean**|  | [optional] [default to true]
 **trending** | **Boolean**|  | [optional] [default to false]

### Return type

[**[ShowDto]**](ShowDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json


## apiShowsIdShowGet

> ShowDto apiShowsIdShowGet(idShow)



### Example

```javascript
import TicketAlarm from 'ticket_alarm';
let defaultClient = TicketAlarm.ApiClient.instance;
// Configure API key authorization: Bearer
let Bearer = defaultClient.authentications['Bearer'];
Bearer.apiKey = 'YOUR API KEY';
// Uncomment the following line to set a prefix for the API key, e.g. "Token" (defaults to null)
//Bearer.apiKeyPrefix = 'Token';

let apiInstance = new TicketAlarm.ShowApi();
let idShow = 56; // Number | 
apiInstance.apiShowsIdShowGet(idShow, (error, data, response) => {
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
 **idShow** | **Number**|  | 

### Return type

[**ShowDto**](ShowDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json


## apiShowsIdShowPut

> ShowDto apiShowsIdShowPut(idShow, opts)



### Example

```javascript
import TicketAlarm from 'ticket_alarm';
let defaultClient = TicketAlarm.ApiClient.instance;
// Configure API key authorization: Bearer
let Bearer = defaultClient.authentications['Bearer'];
Bearer.apiKey = 'YOUR API KEY';
// Uncomment the following line to set a prefix for the API key, e.g. "Token" (defaults to null)
//Bearer.apiKeyPrefix = 'Token';

let apiInstance = new TicketAlarm.ShowApi();
let idShow = 56; // Number | 
let opts = {
  'showDto': new TicketAlarm.ShowDto() // ShowDto | 
};
apiInstance.apiShowsIdShowPut(idShow, opts, (error, data, response) => {
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
 **idShow** | **Number**|  | 
 **showDto** | [**ShowDto**](ShowDto.md)|  | [optional] 

### Return type

[**ShowDto**](ShowDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: application/json, text/json, application/*+json
- **Accept**: text/plain, application/json, text/json


## apiShowsPost

> Number apiShowsPost(opts)



### Example

```javascript
import TicketAlarm from 'ticket_alarm';
let defaultClient = TicketAlarm.ApiClient.instance;
// Configure API key authorization: Bearer
let Bearer = defaultClient.authentications['Bearer'];
Bearer.apiKey = 'YOUR API KEY';
// Uncomment the following line to set a prefix for the API key, e.g. "Token" (defaults to null)
//Bearer.apiKeyPrefix = 'Token';

let apiInstance = new TicketAlarm.ShowApi();
let opts = {
  'baseShowDto': new TicketAlarm.BaseShowDto() // BaseShowDto | 
};
apiInstance.apiShowsPost(opts, (error, data, response) => {
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
 **baseShowDto** | [**BaseShowDto**](BaseShowDto.md)|  | [optional] 

### Return type

**Number**

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: application/json, text/json, application/*+json
- **Accept**: text/plain, application/json, text/json

