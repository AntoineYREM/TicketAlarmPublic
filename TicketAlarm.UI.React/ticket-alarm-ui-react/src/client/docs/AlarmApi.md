# TicketAlarmApi.AlarmApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**apiAlarmsGet**](AlarmApi.md#apiAlarmsGet) | **GET** /api/alarms | 
[**apiAlarmsIdAlarmPut**](AlarmApi.md#apiAlarmsIdAlarmPut) | **PUT** /api/alarms/{idAlarm} | 
[**apiAlarmsPost**](AlarmApi.md#apiAlarmsPost) | **POST** /api/alarms | 



## apiAlarmsGet

> [ShowDto] apiAlarmsGet(opts)



### Example

```javascript
import TicketAlarmApi from 'ticket_alarm_api';

let apiInstance = new TicketAlarmApi.AlarmApi();
let opts = {
  'idShow': 56 // Number | 
};
apiInstance.apiAlarmsGet(opts, (error, data, response) => {
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
 **idShow** | **Number**|  | [optional] 

### Return type

[**[ShowDto]**](ShowDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json


## apiAlarmsIdAlarmPut

> ShowDto apiAlarmsIdAlarmPut(idAlarm, opts)



### Example

```javascript
import TicketAlarmApi from 'ticket_alarm_api';

let apiInstance = new TicketAlarmApi.AlarmApi();
let idAlarm = 56; // Number | 
let opts = {
  'alarmDto': new TicketAlarmApi.AlarmDto() // AlarmDto | 
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

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, application/*+json
- **Accept**: text/plain, application/json, text/json


## apiAlarmsPost

> Number apiAlarmsPost(opts)



### Example

```javascript
import TicketAlarmApi from 'ticket_alarm_api';

let apiInstance = new TicketAlarmApi.AlarmApi();
let opts = {
  'alarmDto': new TicketAlarmApi.AlarmDto() // AlarmDto | 
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

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, application/*+json
- **Accept**: text/plain, application/json, text/json

