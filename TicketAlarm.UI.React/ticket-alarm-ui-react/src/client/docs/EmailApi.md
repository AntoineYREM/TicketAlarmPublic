# TicketAlarmApi.EmailApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**apiEmailPost**](EmailApi.md#apiEmailPost) | **POST** /api/email | 



## apiEmailPost

> Number apiEmailPost(opts)



### Example

```javascript
import TicketAlarmApi from 'ticket_alarm_api';

let apiInstance = new TicketAlarmApi.EmailApi();
let opts = {
  'alarmDto': new TicketAlarmApi.AlarmDto() // AlarmDto | 
};
apiInstance.apiEmailPost(opts, (error, data, response) => {
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

