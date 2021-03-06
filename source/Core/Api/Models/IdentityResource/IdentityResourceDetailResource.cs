﻿/*
 * Copyright 2014 Dominick Baier, Brock Allen, Bert Hoorne
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.Web.Http.Routing;
using IdentityAdmin.Core.IdentityResource;
using IdentityAdmin.Extensions;

namespace IdentityAdmin.Api.Models.IdentityResource
{
    class IdentityResourceDetailResource
    {
        public IdentityResourceDetailResource(IdentityResourceDetail identityResource, UrlHelper url, IdentityResourceMetaData metaData)
        {
            if (identityResource == null) throw new ArgumentNullException(nameof(identityResource));
            if (url == null) throw new ArgumentNullException(nameof(url));
            if (metaData == null) throw new ArgumentNullException(nameof(metaData));

            Data = new IdentityResourceDetailDataResource(identityResource, url, metaData);

            var links = new Dictionary<string, string>();
            if (metaData.SupportsDelete)
            {
                links["Delete"] = url.RelativeLink(Constants.RouteNames.DeleteIdentityResource, new { subject = identityResource.Subject });
            }
            Links = links;
        }

        public IdentityResourceDetailDataResource Data { get; set; }
        public object Links { get; set; }
    }
}
