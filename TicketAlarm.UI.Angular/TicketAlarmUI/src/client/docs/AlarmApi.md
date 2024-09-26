# TicketAlarm.AlarmApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**apiAlarmsIdAlarmPut**](AlarmApi.md#apiAlarmsIdAlarmPut) | **PUT** /api/alarms/{idAlarm} | 
[**apiAlarmsIdShowGet**](AlarmApi.md#apiAlarmsIdShowGet) | **GET** /api/alarms/{idShow} | 
[**apiAlarmsPost**](AlarmApi.md#apiAlarmsPost) | **POST** /api/alarms | 



## apiAlarmsIdAlarmPut

> ShowDto apiAlarmsIdAlarmPut(idAlarm, opts)



### Example

```javascript
import TicketAlarm from 'ticket_alarm';
let defaultClient = TicketAlarm.ApiClient.instance;
// Configure API key authorization: Bearer
let Bearer = defaultClient.authentications['Bearer'];
Bearer.apiKey = 'YOUR API KEY';
// Uncomment the following line to set a prefix for the API key, e.g. "Token" (defaults to null)
//Bearer.apiKeyPrefix = 'Token';

let apiInstance = new TicketAlarm.AlarmApi();
let idAlarm = 56; // Number | 
let opts = {
  'alarmDto': new TicketAlarm.AlarmDto() // AlarmDto | 
};
apiInstance.apiAlarmsIdAlarmPut(idAlarm, opts, (error, data, response) => {
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
 **idAlarm** | **Number**|  | 
 **alarmDto** | [**AlarmDto**](AlarmDto.md)|  | [optional] 

### Return type

[**ShowDto**](ShowDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: application/json, text/json, application/*+json
- **Accept**: text/plain, application/json, text/json


## apiAlarmsIdShowGet

> [ShowDto] apiAlarmsIdShowGet(idShow)



### Example

```javascript
import TicketAlarm from 'ticket_alarm';
let defaultClient = TicketAlarm.ApiClient.instance;
// Configure API key authorization: Bearer
let Bearer = defaultClient.authentications['Bearer'];
Bearer.apiKey = 'YOUR API KEY';
// Uncomment the following line to set a prefix for the API key, e.g. "Token" (defaults to null)
//Bearer.apiKeyPrefix = 'Token';

let apiInstance = new TicketAlarm.AlarmApi();
let idShow = 56; // Number | 
apiInstance.apiAlarmsIdShowGet(idShow, (error, data, response) => {
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

[**[ShowDto]**](ShowDto.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json


## apiAlarmsPost

> Number apiAlarmsPost(opts)



### Example

```javascript
import TicketAlarm from 'ticket_alarm';
let defaultClient = TicketAlarm.ApiClient.instance;
// Configure API key authorization: Bearer
let Bearer = defaultClient.authentications['Bearer'];
Bearer.apiKey = 'YOUR API KEY';
// Uncomment the following line to set a prefix for the API key, e.g. "Token" (defaults to null)
//Bearer.apiKeyPrefix = 'Token';

let apiInstance = new TicketAlarm.AlarmApi();
let opts = {
  'alarmDto': new TicketAlarm.AlarmDto() // AlarmDto | 
};
apiInstance.apiAlarmsPost(opts, (error, data, response) => {
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
 **alarmDto** | [**AlarmDto**](AlarmDto.md)|  | [optional] 

### Return type

**Number**

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: application/json, text/json, application/*+json
- **Accept**: text/plain, application/json, text/json

