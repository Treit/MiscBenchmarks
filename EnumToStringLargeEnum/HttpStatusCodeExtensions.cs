using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;

namespace Test
{
    public static class HttpStatusCodeExtensions
    {
        private static FrozenDictionary<HttpStatusCode, string> _httpStatusCodeToStringCache = GetHttpStatusCodeStrings();

        private static FrozenDictionary<HttpStatusCode, string> GetHttpStatusCodeStrings()
        {
            var dictionary = new Dictionary<HttpStatusCode, string>();

            foreach (HttpStatusCode statusCode in Enum.GetValues(typeof(HttpStatusCode)))
            {
                dictionary[statusCode] = statusCode.ToString();
            }

            return dictionary.ToFrozenDictionary();
        }

        // Array-based lookup for even faster access
        private static readonly string[] _httpStatusCodeStrings = InitializeHttpStatusCodeStrings();

        private static string[] InitializeHttpStatusCodeStrings()
        {
            // Find max enum value to determine array size
            int maxValue = 0;
            foreach (HttpStatusCode value in Enum.GetValues(typeof(HttpStatusCode)))
            {
                int intValue = (int)value;
                if (intValue > maxValue)
                {
                    maxValue = intValue;
                }
            }

            // Create and populate the array
            string[] result = new string[maxValue + 1];

            foreach (HttpStatusCode value in Enum.GetValues(typeof(HttpStatusCode)))
            {
                result[(int)value] = value.ToString();
            }

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToArrayString(this HttpStatusCode statusCode)
        {
            int index = (int)statusCode;

            if ((uint)index < (uint)_httpStatusCodeStrings.Length)
            {
                string? result = _httpStatusCodeStrings[index];
                if (result != null)
                {
                    return result;
                }
            }

            return statusCode.ToString();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToArrayStringDominic(this HttpStatusCode statusCode)
        {
            int index = (int)statusCode;

            if (index < 0 || index >= _httpStatusCodeStrings.Length || _httpStatusCodeStrings[index] == null)
            {
                return index.ToString();
            }

            return _httpStatusCodeStrings[index];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToArrayStringMtreit(this HttpStatusCode statusCode)
        {
            int index = (int)statusCode;

            if (index >= 0 && index < _httpStatusCodeStrings.Length)
            {
                string? result = _httpStatusCodeStrings[index];

                if (result != null)
                {
                    return result;
                }
            }

            return index.ToString();
        }

        public static string ToFastString(this HttpStatusCode statusCode) => statusCode switch
        {
            HttpStatusCode.OK => "OK",
            HttpStatusCode.Created => "Created",
            HttpStatusCode.Accepted => "Accepted",
            HttpStatusCode.MovedPermanently or HttpStatusCode.Moved => "Moved",
            HttpStatusCode.MultipleChoices or HttpStatusCode.Ambiguous => "Ambiguous",
            HttpStatusCode.Redirect or HttpStatusCode.Found => "Found",
            HttpStatusCode.SeeOther or HttpStatusCode.RedirectMethod => "RedirectMethod",
            HttpStatusCode.TemporaryRedirect or HttpStatusCode.RedirectKeepVerb => "TemporaryRedirect",
            HttpStatusCode.NoContent => "NoContent",
            HttpStatusCode.Continue => "Continue",
            HttpStatusCode.SwitchingProtocols => "SwitchingProtocols",
            HttpStatusCode.Processing => "Processing",
            HttpStatusCode.EarlyHints => "EarlyHints",
            HttpStatusCode.NonAuthoritativeInformation => "NonAuthoritativeInformation",
            HttpStatusCode.ResetContent => "ResetContent",
            HttpStatusCode.PartialContent => "PartialContent",
            HttpStatusCode.MultiStatus => "MultiStatus",
            HttpStatusCode.AlreadyReported => "AlreadyReported",
            HttpStatusCode.IMUsed => "IMUsed",
            HttpStatusCode.NotModified => "NotModified",
            HttpStatusCode.UseProxy => "UseProxy",
            HttpStatusCode.Unused => "Unused",
            HttpStatusCode.PermanentRedirect => "PermanentRedirect",
            HttpStatusCode.BadRequest => "BadRequest",
            HttpStatusCode.Unauthorized => "Unauthorized",
            HttpStatusCode.PaymentRequired => "PaymentRequired",
            HttpStatusCode.Forbidden => "Forbidden",
            HttpStatusCode.NotFound => "NotFound",
            HttpStatusCode.MethodNotAllowed => "MethodNotAllowed",
            HttpStatusCode.NotAcceptable => "NotAcceptable",
            HttpStatusCode.ProxyAuthenticationRequired => "ProxyAuthenticationRequired",
            HttpStatusCode.RequestTimeout => "RequestTimeout",
            HttpStatusCode.Conflict => "Conflict",
            HttpStatusCode.Gone => "Gone",
            HttpStatusCode.LengthRequired => "LengthRequired",
            HttpStatusCode.PreconditionFailed => "PreconditionFailed",
            HttpStatusCode.RequestEntityTooLarge => "RequestEntityTooLarge",
            HttpStatusCode.RequestUriTooLong => "RequestUriTooLong",
            HttpStatusCode.UnsupportedMediaType => "UnsupportedMediaType",
            HttpStatusCode.RequestedRangeNotSatisfiable => "RequestedRangeNotSatisfiable",
            HttpStatusCode.ExpectationFailed => "ExpectationFailed",
            HttpStatusCode.MisdirectedRequest => "MisdirectedRequest",
            HttpStatusCode.UnprocessableEntity => "UnprocessableEntity",
            HttpStatusCode.Locked => "Locked",
            HttpStatusCode.FailedDependency => "FailedDependency",
            HttpStatusCode.UpgradeRequired => "UpgradeRequired",
            HttpStatusCode.PreconditionRequired => "PreconditionRequired",
            HttpStatusCode.TooManyRequests => "TooManyRequests",
            HttpStatusCode.RequestHeaderFieldsTooLarge => "RequestHeaderFieldsTooLarge",
            HttpStatusCode.UnavailableForLegalReasons => "UnavailableForLegalReasons",
            HttpStatusCode.InternalServerError => "InternalServerError",
            HttpStatusCode.NotImplemented => "NotImplemented",
            HttpStatusCode.BadGateway => "BadGateway",
            HttpStatusCode.ServiceUnavailable => "ServiceUnavailable",
            HttpStatusCode.GatewayTimeout => "GatewayTimeout",
            HttpStatusCode.HttpVersionNotSupported => "HttpVersionNotSupported",
            HttpStatusCode.VariantAlsoNegotiates => "VariantAlsoNegotiates",
            HttpStatusCode.InsufficientStorage => "InsufficientStorage",
            HttpStatusCode.LoopDetected => "LoopDetected",
            HttpStatusCode.NotExtended => "NotExtended",
            HttpStatusCode.NetworkAuthenticationRequired => "NetworkAuthenticationRequired",
            _ => ((int)statusCode).ToString(), // due to: https://github.com/WalkerCodeRanger/ExhaustiveMatching/issues/52
        };

        public static string ToStringCached(this HttpStatusCode statusCode)
        {
            if (_httpStatusCodeToStringCache.TryGetValue(statusCode, out var result))
            {
                return result;
            }

            // Edge case that we don't expect to really happen.
            result = statusCode.ToString();
            return result;
        }
    }
}