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
	// Mixin content Type 1080 with alias "imageFavicon"
	/// <summary>_ImageFavicon</summary>
	public partial interface IImageFavicon : IPublishedContent
	{
		/// <summary>Favicon</summary>
		IPublishedContent Favicon { get; }
	}

	/// <summary>_ImageFavicon</summary>
	[PublishedContentModel("imageFavicon")]
	public partial class ImageFavicon : PublishedContentModel, IImageFavicon
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "imageFavicon";
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

		public ImageFavicon(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<ImageFavicon, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// Favicon
		///</summary>
		[ImplementPropertyType("favicon")]
		public IPublishedContent Favicon
		{
			get { return GetFavicon(this); }
		}

		/// <summary>Static getter for Favicon</summary>
		public static IPublishedContent GetFavicon(IImageFavicon that) { return that.GetPropertyValue<IPublishedContent>("favicon"); }
	}
}
