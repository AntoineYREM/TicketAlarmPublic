# TicketAlarmApi.ArtistApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**apiArtistsGet**](ArtistApi.md#apiArtistsGet) | **GET** /api/artists | 
[**apiArtistsPost**](ArtistApi.md#apiArtistsPost) | **POST** /api/artists | 



## apiArtistsGet

> [ArtistDto] apiArtistsGet()



### Example

```javascript
import TicketAlarmApi from 'ticket_alarm_api';

let apiInstance = new TicketAlarmApi.ArtistApi();
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

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json


## apiArtistsPost

> Number apiArtistsPost(opts)



### Example

```javascript
import TicketAlarmApi from 'ticket_alarm_api';

let apiInstance = new TicketAlarmApi.ArtistApi();
let opts = {
  'artistDto': new TicketAlarmApi.ArtistDto() // ArtistDto | 
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

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, application/*+json
- **Accept**: text/plain, application/json, text/json

