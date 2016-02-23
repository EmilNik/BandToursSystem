namespace SimilarBeads.Web.Infrastructure.CustomAttributes
{
    using System;
    using System.Web.Mvc;

    [AttributeUsage(AttributeTargets.Property)]
    public class AutocompleteAttribute : Attribute, IMetadataAware
    {
        private readonly string controller;
        private readonly string action;

        public AutocompleteAttribute(string controller, string action)
        {
            this.controller = controller;
            this.action = action;
        }

        public void OnMetadataCreated(ModelMetadata metadata)
        {
            metadata.SetAutoComplete(this.controller, this.action);
        }
    }
}