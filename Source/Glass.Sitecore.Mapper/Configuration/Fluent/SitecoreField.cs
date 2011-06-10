﻿/*
   Copyright 2011 Michael Edwards
 
   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Glass.Sitecore.Mapper.Configuration.Fluent
{
	public class SitecoreField<T>: ISitecoreAttributeBuilder
	{
        Configuration.Attributes.SitecoreFieldAttribute _attr;
 
        public SitecoreField()
        {
            _attr = new Configuration.Attributes.SitecoreFieldAttribute(); 
        }

        public SitecoreField<T> ReadOnly()
        {
            _attr.ReadOnly = true;
            return this;
        }

        public SitecoreField<T> FieldName(string name)
        {
            _attr.FieldName = name;
            return this;
        }
        public SitecoreField<T> Setting(SitecoreFieldSettings setting)
        {
            _attr.Setting = setting;
            return this;
        }


        #region ISitecoreAttributeBuilder Members

        public Glass.Sitecore.Mapper.Configuration.Attributes.AbstractSitecorePropertyAttribute Attribute
        {
            get { return _attr; }
        }

        #endregion
    }
}
