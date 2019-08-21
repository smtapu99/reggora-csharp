using Reggora.Api.Entity;
using RestSharp;

namespace Reggora.Api.Requests.Lender.Orders
{
    public class CancelOrderRequest : ReggoraRequest
    {
        public CancelOrderRequest(string orderId) : base("lender/order/{order_id}/cancel", Method.DELETE)
        {
            AddParameter("order_id", orderId, ParameterType.UrlSegment);
        }
    }
}