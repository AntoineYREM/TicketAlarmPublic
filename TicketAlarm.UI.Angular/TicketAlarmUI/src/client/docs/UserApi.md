# TicketAlarm.UserApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**authenticatePost**](UserApi.md#authenticatePost) | **POST** /authenticate | 



## authenticatePost

> String authenticatePost(opts)



### Example

```javascript
import TicketAlarm from 'ticket_alarm';
let defaultClient = TicketAlarm.ApiClient.instance;
// Configure API key authorization: Bearer
let Bearer = defaultClient.authentications['Bearer'];
Bearer.apiKey = 'YOUR API KEY';
// Uncomment the following line to set a prefix for the API key, e.g. "Token" (defaults to null)
//Bearer.apiKeyPrefix = 'Token';

let apiInstance = new TicketAlarm.UserApi();
let opts = {
  'loginUserDto': new TicketAlarm.LoginUserDto() // LoginUserDto | 
};
apiInstance.authenticatePost(opts, (error, data, response) => {
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
 **loginUserDto** | [**LoginUserDto**](LoginUserDto.md)|  | [optional] 

### Return type

**String**

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: application/json, text/json, application/*+json
- **Accept**: text/plain, application/json, text/json

