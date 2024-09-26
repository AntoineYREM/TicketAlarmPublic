# TicketAlarm.AvailabilityApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**apiAvailabilitysPost**](AvailabilityApi.md#apiAvailabilitysPost) | **POST** /api/availabilitys | 



## apiAvailabilitysPost

> [Number] apiAvailabilitysPost(opts)



### Example

```javascript
import TicketAlarm from 'ticket_alarm';
let defaultClient = TicketAlarm.ApiClient.instance;
// Configure API key authorization: Bearer
let Bearer = defaultClient.authentications['Bearer'];
Bearer.apiKey = 'YOUR API KEY';
// Uncomment the following line to set a prefix for the API key, e.g. "Token" (defaults to null)
//Bearer.apiKeyPrefix = 'Token';

let apiInstance = new TicketAlarm.AvailabilityApi();
let opts = {
  'availabilityDto': new TicketAlarm.AvailabilityDto() // AvailabilityDto | 
};
apiInstance.apiAvailabilitysPost(opts, (error, data, response) => {
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
 **availabilityDto** | [**AvailabilityDto**](AvailabilityDto.md)|  | [optional] 

### Return type

**[Number]**

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: application/json, text/json, application/*+json
- **Accept**: text/plain, application/json, text/json

