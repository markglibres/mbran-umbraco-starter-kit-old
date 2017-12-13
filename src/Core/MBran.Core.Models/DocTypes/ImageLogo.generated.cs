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

namespace MBran.Core.Models
{
	// Mixin content Type 1081 with alias "imageLogo"
	/// <summary>_ImageLogo</summary>
	public partial interface IImageLogo : IPublishedContent
	{
		/// <summary>Logo</summary>
		IPublishedContent Logo { get; }
	}

	/// <summary>_ImageLogo</summary>
	[PublishedContentModel("imageLogo")]
	public partial class ImageLogo : PublishedContentModel, IImageLogo
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "imageLogo";
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

		public ImageLogo(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<ImageLogo, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// Logo
		///</summary>
		[ImplementPropertyType("logo")]
		public IPublishedContent Logo
		{
			get { return GetLogo(this); }
		}

		/// <summary>Static getter for Logo</summary>
		public static IPublishedContent GetLogo(IImageLogo that) { return that.GetPropertyValue<IPublishedContent>("logo"); }
	}
}
