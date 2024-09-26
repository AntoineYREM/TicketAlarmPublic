# TicketAlarm.EmailApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**apiEmailPost**](EmailApi.md#apiEmailPost) | **POST** /api/email | 



## apiEmailPost

> Number apiEmailPost(opts)



### Example

```javascript
import TicketAlarm from 'ticket_alarm';
let defaultClient = TicketAlarm.ApiClient.instance;
// Configure API key authorization: Bearer
let Bearer = defaultClient.authentications['Bearer'];
Bearer.apiKey = 'YOUR API KEY';
// Uncomment the following line to set a prefix for the API key, e.g. "Token" (defaults to null)
//Bearer.apiKeyPrefix = 'Token';

let apiInstance = new TicketAlarm.EmailApi();
let opts = {
  'alarmDto': new TicketAlarm.AlarmDto() // AlarmDto | 
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

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: application/json, text/json, application/*+json
- **Accept**: text/plain, application/json, text/json

