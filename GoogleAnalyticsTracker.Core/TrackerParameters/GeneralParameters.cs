using GoogleAnalyticsTracker.Core.TrackerParameters.Interface;

namespace GoogleAnalyticsTracker.Core.TrackerParameters
{
    public abstract class GeneralParameters : IGeneralParameters
    {
        protected GeneralParameters()
        {
            NonInteractionHit = GoogleBoolean.False;
        }

        public string UserAgent { get; set; }
        public string ReferralUrl { get; set; }

        #region Implementation of IGeneralParameters

        /// <summary>
        /// The Protocol version. The current value is '1'. This will only change when there are changes made that are not backwards compatible.
        /// <remarks>Required for all hit types</remarks>
        /// </summary>        
        [Beacon("v", true)]
        public string ProtocolVersion
        {
            get { return "1"; }
        }

        /// <summary>
        /// The tracking ID / web property ID. The format is UA-XXXX-Y. All collected data is associated by this ID.
        /// <remarks>Required for all hit types</remarks>
        /// <example>UA-XXXX-Y</example>
        /// </summary>
        [Beacon("tid", true)]
        public string TrackingId { get; set; }

        /// <summary>
        /// When present, the IP address of the sender will be anonymized. 
        /// For example, the IP will be anonymized if any of the following parameters are present in the payload: &amp;aip=, &amp;aip=0, or &amp;aip=1
        /// <remarks>Optional</remarks>
        /// <example>GoogleBoolean.True</example>
        /// </summary>         
        [Beacon("aip", false, true)]
        public GoogleBoolean? AnonymizeIp { get; set; }

        /// <summary>
        /// Used to collect offline / latent hits. 
        /// The value represents the time delta (in milliseconds) between when the hit being reported occurred and the time the hit was sent. 
        /// The value must be greater than or equal to 0. Values greater than four hours may lead to hits not being processed.
        /// <remarks>Optional</remarks>
        /// <example>560</example>
        /// </summary>
        [Beacon("qt")]
        public long? QueueTime { get; set; }

        /// <summary>
        /// Used to send a random number in GET requests to ensure browsers and proxies don't cache hits. 
        /// It should be sent as the final parameter of the request since we've seen some 3rd party internet filtering software add additional parameters to HTTP requests incorrectly. This value is not used in reporting.
        /// <remarks>Optional</remarks>
        /// <example>289372387623</example>
        /// </summary>   
        [Beacon("z")]
        public string CacheBuster { get; set; }

        #endregion

        #region Implementation of IHitParameters

        /// <summary>
        /// The type of hit. Must be one of 'pageview', 'screenview', 'event', 'transaction', 'item', 'social', 'exception', 'timing'.
        /// <remarks>Required for all hit types</remarks>
        /// <example>HitType.Pageview</example>
        /// </summary>  
        [Beacon("t", true)]
        public abstract HitType HitType { get; }

        /// <summary>
        /// Specifies that a hit be considered non-interactive.
        /// <remarks>Optional</remarks>
        /// <example>GoogleBoolean.True</example>
        /// </summary>                
        [Beacon("ni", false, true)]
        public GoogleBoolean? NonInteractionHit { get; set; }

        #endregion

        #region Implementation of IUserParameters

        /// <summary>
        /// This anonymously identifies a particular user, device, or browser instance. 
        /// For the web, this is generally stored as a first-party cookie with a two-year expiration. For mobile apps, this is randomly generated for each particular instance of an application install. 
        /// The value of this field should be a random UUID (version 4) as described in http://www.ietf.org/rfc/rfc4122.txt
        /// <remarks>Required for all hit types</remarks>
        /// <example>35009a79-1a05-49d7-b876-2b884d0f825b</example>
        /// </summary>
        [Beacon("cid", true)]
        public string ClientId { get; set; }

        /// <summary>
        /// This is intended to be a known identifier for a user provided by the site owner/tracking library user. 
        /// It may not itself be PII (personally identifiable information). 
        /// The value should never be persisted in GA cookies or other Analytics provided storage.
        /// <remarks>Optional</remarks>
        /// <example>as8eknlll</example>
        /// </summary>   
        [Beacon("uid")]
        public string UserId { get; set; }

        #endregion

        #region Implementation of ISystemInfoParameters

        /// <summary>
        /// Specifies the screen resolution
        /// <remarks>Optional</remarks>
        /// <example>800x600</example>
        /// </summary>        
        [Beacon("sr")]
        public string ScreenResolution { get; set; }

        /// <summary>
        /// Specifies the viewable area of the browser / device.
        /// <remarks>Optional</remarks>
        /// <example>123x456</example>
        /// </summary>        
        [Beacon("vp")]
        public string ViewportSize { get; set; }

        /// <summary>
        /// Specifies the character set used to encode the page / document.
        /// <remarks>Optional</remarks>
        /// <example>UTF-8</example>
        /// </summary>        
        [Beacon("de")]
        public string DocumentEncoding { get; set; }

        /// <summary>
        /// Specifies the screen color depth.
        /// <remarks>Optional</remarks>
        /// <example>24-bits</example>
        /// </summary>        
        [Beacon("sd")]
        public string ScreenColors { get; set; }

        /// <summary>
        /// Specifies the language.
        /// <remarks>Optional</remarks>
        /// <example>en-us</example>        
        /// </summary>      
        [Beacon("ul")]
        public string UserLanguage { get; set; }

        /// <summary>
        /// Specifies whether Java was enabled.
        /// <remarks>Optional</remarks>
        /// <example>GoogleBoolean.True</example>
        /// </summary>                
        [Beacon("je", false, true)]
        public GoogleBoolean? JavaEnabled { get; set; }

        /// <summary>
        /// Specifies the flash version.
        /// <remarks>Optional</remarks>
        /// <example>10 1 r103</example>
        /// </summary>       
        [Beacon("fl")]
        public string FlashVersion { get; set; }

        #endregion

        #region Implementation of IContentInformationParameters

        /// <summary>
        /// Use this parameter to send the full URL (document location) of the page on which content resides. 
        /// You can use the &amp;dh and &amp;dp parameters to override the hostname and path + query portions of the document location, accordingly. 
        /// The JavaScript clients determine this parameter using the concatenation of the document.location.origin + document.location.pathname + document.location.search browser parameters. 
        /// Be sure to remove any user authentication or other private information from the URL if present.
        /// <remarks>Optional (For 'pageview' hits, either &amp;dl or both &amp;dh and &amp;dp have to be specified for the hit to be valid)</remarks>
        /// <example>http://foo.com/home?a=b</example>
        /// </summary>
        [Beacon("dl", true)]
        public string DocumentLocationUrl { get; set; }

        /// <summary>
        /// Specifies the hostname from which content was hosted.
        /// <remarks>Optional</remarks>
        /// <example>foo.com</example>
        /// </summary>
        [Beacon("dh")]
        public string DocumentHostName { get; set; }

        /// <summary>
        /// he path portion of the page URL.
        /// <remarks>Optional (Should begin with '/'. For 'pageview' hits, either &amp;dl or both &amp;dh and &amp;dp have to be specified for the hit to be valid.)</remarks>
        /// <example>/foo</example>
        /// </summary>
        [Beacon("dp", true)]
        public string DocumentPath { get; set; }

        /// <summary>
        /// The title of the page / document.
        /// <remarks>Optional</remarks>
        /// <example>Settings</example>
        /// </summary>
        [Beacon("dt")]
        public string DocumentTitle { get; set; }

        /// <summary>
        /// If not specified, this will default to the unique URL of the page by either using the &amp;dl parameter as-is or assembling it from &amp;dh and &amp;dp. 
        /// App tracking makes use of this for the 'Screen Name' of the screenview hit.
        /// <remarks>Optional</remarks>
        /// <example>High Scores</example>
        /// </summary>
        [Beacon("cd")]
        public string ScreenName { get; set; }

        /// <summary>
        /// The ID of a clicked DOM element, used to disambiguate multiple links to the same URL in In-Page Analytics reports when Enhanced Link Attribution is enabled for the property.
        /// <remarks>Optional</remarks>
        /// <example>nav_bar</example>
        /// </summary>
        [Beacon("linkid")]
        public string LinkId { get; set; }

        #endregion

        #region Implementation of ISessionParameters

        /// <summary>
        /// Used to control the session duration. 
        /// A value of 'start' forces a new session to start with this hit and 'end' forces the current session to end with this hit. 
        /// All other values are ignored.
        /// <remarks>Optional</remarks>
        /// <example>SessionControl.Start</example>
        /// </summary>
        [Beacon("sc")]
        public SessionControl? SessionControl { get; set; }

        /// <summary>
        /// The IP address of the user. This should be a valid IP address. It will always be anonymized just as though &amp;aip (anonymize IP) had been used.
        /// <remarks>Optional</remarks>
        /// <example>1.2.3.4</example>
        /// </summary>
        [Beacon("uip")]
        public string IpOverride { get; set; }

        /// <summary>
        /// The User Agent of the browser. Note that Google has libraries to identify real user agents. 
        /// Hand crafting your own agent could break at any time.
        /// <remarks>Optional</remarks>
        /// <example>Opera/9.80 (Windows NT 6.0) Presto/2.12.388 Version/12.14</example>
        /// </summary>
        [Beacon("ua")]
        public string UserAgentOverride { get; set; }

        #endregion

        #region Implementation of ITrafficSourceParameters

        /// <summary>
        /// Specifies which referral source brought traffic to a website. 
        /// This value is also used to compute the traffic source. The format of this value is a URL.
        /// <remarks>Optional</remarks>
        /// <example>http://example.com</example>
        /// </summary>
        [Beacon("dr")]
        public string DocumentReferrer { get; set; }

        /// <summary>
        /// Specifies the campaign name.
        /// <remarks>Optional</remarks>
        /// <example>(direct)</example>
        /// </summary>
        [Beacon("cn")]
        public string CampaignName { get; set; }

        /// <summary>
        /// Specifies the campaign source.
        /// <remarks>Optional</remarks>
        /// <example>(direct)</example>
        /// </summary>
        [Beacon("cs")]
        public string CampaignSource { get; set; }

        /// <summary>
        /// Specifies the campaign medium.
        /// <remarks>Optional</remarks>
        /// <example>organic</example>
        /// </summary>
        [Beacon("cm")]
        public string CampaignMedium { get; set; }

        /// <summary>
        /// Specifies the campaign keyword.
        /// <remarks>Optional</remarks>
        /// <example>Blue Shoes</example>
        /// </summary>
        [Beacon("ck")]
        public string CampaignKeyword { get; set; }

        /// <summary>
        /// Specifies the campaign content.
        /// <remarks>Optional</remarks>
        /// <example>content</example>
        /// </summary>
        [Beacon("cc")]
        public string CampaignContent { get; set; }

        /// <summary>
        /// Specifies the campaign ID.
        /// <remarks>Optional</remarks>
        /// <example>ID</example>
        /// </summary>
        [Beacon("ci")]
        public string CampaignId { get; set; }

        /// <summary>
        /// Specifies the Google AdWords Id.
        /// <remarks>Optional</remarks>
        /// <example>CL6Q-OXyqKUCFcgK2goddQuoHg</example>
        /// </summary>
        [Beacon("gclid")]
        public string GoogleAdWordsId { get; set; }

        /// <summary>
        /// Specifies the Google Display Ads Id.
        /// <remarks>Optional</remarks>
        /// <example>d_click_id</example>
        /// </summary>
        [Beacon("dclid")]
        public string GoogleDisplayAdsId { get; set; }

        #endregion
    }
}