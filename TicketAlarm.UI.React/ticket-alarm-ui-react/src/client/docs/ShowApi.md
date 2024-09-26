# TicketAlarmApi.ShowApi

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
import TicketAlarmApi from 'ticket_alarm_api';

let apiInstance = new TicketAlarmApi.ShowApi();
let opts = {
  'active': true // Boolean | 
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
 **active** | **Boolean**|  | [optional] 

### Return type

[**[ShowDto]**](ShowDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json


## apiShowsIdShowGet

> ShowDto apiShowsIdShowGet(idShow)



### Example

```javascript
import TicketAlarmApi from 'ticket_alarm_api';

let apiInstance = new TicketAlarmApi.ShowApi();
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

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json


## apiShowsIdShowPut

> ShowDto apiShowsIdShowPut(idShow, opts)



### Example

```javascript
import TicketAlarmApi from 'ticket_alarm_api';

let apiInstance = new TicketAlarmApi.ShowApi();
let idShow = 56; // Number | 
let opts = {
  'showDto': new TicketAlarmApi.ShowDto() // ShowDto | 
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

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, application/*+json
- **Accept**: text/plain, application/json, text/json


## apiShowsPost

> Number apiShowsPost(opts)



### Example

```javascript
import TicketAlarmApi from 'ticket_alarm_api';

let apiInstance = new TicketAlarmApi.ShowApi();
let opts = {
  'showDto': new TicketAlarmApi.ShowDto() // ShowDto | 
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
 **showDto** | [**ShowDto**](ShowDto.md)|  | [optional] 

### Return type

**Number**

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, application/*+json
- **Accept**: text/plain, application/json, text/json

