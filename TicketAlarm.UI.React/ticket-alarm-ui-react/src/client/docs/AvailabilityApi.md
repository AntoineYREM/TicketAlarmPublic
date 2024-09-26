# TicketAlarmApi.AvailabilityApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**apiAvailabilitysPost**](AvailabilityApi.md#apiAvailabilitysPost) | **POST** /api/availabilitys | 



## apiAvailabilitysPost

> [Number] apiAvailabilitysPost(opts)



### Example

```javascript
import TicketAlarmApi from 'ticket_alarm_api';

let apiInstance = new TicketAlarmApi.AvailabilityApi();
let opts = {
  'availabilityDto': new TicketAlarmApi.AvailabilityDto() // AvailabilityDto | 
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

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, application/*+json
- **Accept**: text/plain, application/json, text/json

