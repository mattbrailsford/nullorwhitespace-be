﻿using AutoMapper;
using NullOrWhitespace.Models;
using NullOrWhitespace.Web.Mapping.Resolvers;
using NullOrWhitespace.Web.ViewModels;
using System.Linq;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace NullOrWhitespace.Web.Mapping
{
    public class ViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            // Common
            Mapper.CreateMap<Page, BasePageViewModel>()
                .ForMember(x => x.Type, o => o.MapFrom(x => x.DocumentTypeAlias))
                .ForMember(x => x.MetaTitle, o => o.ResolveUsing<MetaTitleResolver>());

            Mapper.CreateMap<SocialLink, SocialLinkViewModel>()
                .ForMember(x => x.Url, o => o.MapFrom(x => x.ProfileUrl))
                .ForMember(x => x.Type, o => o.MapFrom(x => x.DocumentTypeAlias.TrimEnd("Link")));

            // HomePage
            Mapper.CreateMap<HomePage, HomePageViewModel>()
                .IncludeBase<Page, BasePageViewModel>()
                .ForMember(x => x.Image, o => o.MapFrom(x => x.Image.Url))
                .ForMember(x => x.LatestBlogPosts, o => o.ResolveUsing<LatestBlogPostsResolver>());

            Mapper.CreateMap<HomePage, InitViewModel>();

            Mapper.CreateMap<HomePage, RoutesViewModel>()
                .ForMember(x => x.Routes, o => o.ResolveUsing<RoutesResolver>());

            // StandardPage
            Mapper.CreateMap<StandardPage, StandardPageViewModel>()
                .IncludeBase<Page, BasePageViewModel>();

            // BlogPage
            Mapper.CreateMap<BlogPage, BlogPageViewModel>()
                .IncludeBase<Page, BasePageViewModel>()
                .ForMember(x => x.BlogPosts, o => o.MapFrom(x => x.Children.Where(y => y.IsVisible())));

            // BlogPostPage
            Mapper.CreateMap<BlogPostPage, BaseBlogPostPageViewModel>()
                .IncludeBase<Page, BasePageViewModel>()
                .ForMember(x => x.Author, o => o.MapFrom(x => x.WriterName));

            Mapper.CreateMap<BlogPostPage, BlogPostPageViewModel>()
                .IncludeBase<BlogPostPage, BaseBlogPostPageViewModel>();

            // Content blocks
            Mapper.CreateMap<IPublishedContent, BaseBlockViewModel>()
                .ForMember(x => x.Type, o => o.MapFrom(x => x.DocumentTypeAlias));

            Mapper.CreateMap<RichTextBlock, RichTextBlockViewModel>()
                .IncludeBase<IPublishedContent, BaseBlockViewModel>();

            Mapper.CreateMap<ImageBlock, ImageBlockViewModel>()
                .IncludeBase<IPublishedContent, BaseBlockViewModel>()
                .ForMember(x => x.Image, o => o.MapFrom(x => x.Image.Url));

            Mapper.CreateMap<CodeBlock, ImageBlockViewModel>()
                .IncludeBase<IPublishedContent, CodeBlockViewModel>();
        }
    }
}
