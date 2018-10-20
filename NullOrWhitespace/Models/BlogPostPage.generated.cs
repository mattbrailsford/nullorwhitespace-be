//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder v3.0.10.102
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

namespace NullOrWhitespace.Models
{
	/// <summary>Blog Post Page</summary>
	[PublishedContentModel("blogPostPage")]
	public partial class BlogPostPage : Page
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "blogPostPage";
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

		public BlogPostPage(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<BlogPostPage, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// Blocks: Content blocks to make up date main content of this page.
		///</summary>
		[ImplementPropertyType("blocks")]
		public IEnumerable<IPublishedContent> Blocks
		{
			get { return this.GetPropertyValue<IEnumerable<IPublishedContent>>("blocks"); }
		}

		///<summary>
		/// Excerpt: Short excerpt for this block post.
		///</summary>
		[ImplementPropertyType("excerpt")]
		public string Excerpt
		{
			get { return this.GetPropertyValue<string>("excerpt"); }
		}

		///<summary>
		/// Publish Date: Date the article was published.
		///</summary>
		[ImplementPropertyType("publishDate")]
		public DateTime PublishDate
		{
			get { return this.GetPropertyValue<DateTime>("publishDate"); }
		}
	}
}
