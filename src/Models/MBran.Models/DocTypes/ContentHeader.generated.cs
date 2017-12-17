//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder v3.0.7.99
//
//   Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.ModelsBuilder;
using Umbraco.ModelsBuilder.Umbraco;

namespace MBran.Models
{
	// Mixin content Type 1077 with alias "contentHeader"
	/// <summary>_ContentHeader</summary>
	public partial interface IContentHeader : IPublishedContent
	{
		/// <summary>Summary</summary>
		string ContentSummary { get; }

		/// <summary>Title</summary>
		string ContentTitle { get; }
	}

	/// <summary>_ContentHeader</summary>
	[PublishedContentModel("contentHeader")]
	public partial class ContentHeader : PublishedContentModel, IContentHeader
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "contentHeader";
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

		public ContentHeader(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<ContentHeader, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// Summary
		///</summary>
		[ImplementPropertyType("contentSummary")]
		public string ContentSummary
		{
			get { return GetContentSummary(this); }
		}

		/// <summary>Static getter for Summary</summary>
		public static string GetContentSummary(IContentHeader that) { return that.GetPropertyValue<string>("contentSummary"); }

		///<summary>
		/// Title
		///</summary>
		[ImplementPropertyType("contentTitle")]
		public string ContentTitle
		{
			get { return GetContentTitle(this); }
		}

		/// <summary>Static getter for Title</summary>
		public static string GetContentTitle(IContentHeader that) { return that.GetPropertyValue<string>("contentTitle"); }
	}
}
