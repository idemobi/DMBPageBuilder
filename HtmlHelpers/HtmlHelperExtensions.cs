#region Copyright

// ©2002-2026 idéMobi
// www.idemobi.com

#endregion

#region

using Microsoft.AspNetCore.Mvc.Rendering;

#endregion

namespace DMBPageBuilder
{
    /// <summary>
    ///     Provides Razor HTML helper factories for PageBuilder tag builders.
    /// </summary>
    public static class HtmlHelperExtensions
    {
        #region Static methods

        /// <summary>
        ///     Creates a <see cref="PB_AnchorBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_AnchorBuilder" /> instance.</returns>
        public static PB_AnchorBuilder PB_A(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_AbbrBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_AbbrBuilder" /> instance.</returns>
        public static PB_AbbrBuilder PB_Abbr(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_AcronymBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_AcronymBuilder" /> instance.</returns>
        [Obsolete("acronym is obsolete in HTML5.")]
        public static PB_AcronymBuilder PB_Acronym(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_AddressBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_AddressBuilder" /> instance.</returns>
        public static PB_AddressBuilder PB_Address(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_ArticleBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_ArticleBuilder" /> instance.</returns>
        public static PB_ArticleBuilder PB_Article(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_AsideBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_AsideBuilder" /> instance.</returns>
        public static PB_AsideBuilder PB_Aside(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_AudioBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_AudioBuilder" /> instance.</returns>
        public static PB_AudioBuilder PB_Audio(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_BBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_BBuilder" /> instance.</returns>
        public static PB_BBuilder PB_B(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_BaseBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_BaseBuilder" /> instance.</returns>
        public static PB_BaseBuilder PB_Base(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_BdiBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_BdiBuilder" /> instance.</returns>
        public static PB_BdiBuilder PB_Bdi(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_BdoBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_BdoBuilder" /> instance.</returns>
        public static PB_BdoBuilder PB_Bdo(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_BigBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_BigBuilder" /> instance.</returns>
        [Obsolete("big is obsolete in HTML5.")]
        public static PB_BigBuilder PB_Big(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_BlockquoteBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_BlockquoteBuilder" /> instance.</returns>
        public static PB_BlockquoteBuilder PB_Blockquote(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_BodyTagBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_BodyTagBuilder" /> instance.</returns>
        public static PB_BodyTagBuilder PB_BodyTag(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_BrBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_BrBuilder" /> instance.</returns>
        public static PB_BrBuilder PB_Br(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_ButtonBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_ButtonBuilder" /> instance.</returns>
        public static PB_ButtonBuilder PB_ButtonTag(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_CanvasBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_CanvasBuilder" /> instance.</returns>
        public static PB_CanvasBuilder PB_Canvas(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_CaptionBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_CaptionBuilder" /> instance.</returns>
        public static PB_CaptionBuilder PB_Caption(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_CiteBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_CiteBuilder" /> instance.</returns>
        public static PB_CiteBuilder PB_Cite(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_CodeBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_CodeBuilder" /> instance.</returns>
        public static PB_CodeBuilder PB_Code(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_ColBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_ColBuilder" /> instance.</returns>
        public static PB_ColBuilder PB_Col(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_ColgroupBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_ColgroupBuilder" /> instance.</returns>
        public static PB_ColgroupBuilder PB_Colgroup(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_DataBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_DataBuilder" /> instance.</returns>
        public static PB_DataBuilder PB_Data(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_DatalistBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_DatalistBuilder" /> instance.</returns>
        public static PB_DatalistBuilder PB_Datalist(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_DdBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_DdBuilder" /> instance.</returns>
        public static PB_DdBuilder PB_Dd(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_DelBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_DelBuilder" /> instance.</returns>
        public static PB_DelBuilder PB_Del(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_DetailsBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_DetailsBuilder" /> instance.</returns>
        public static PB_DetailsBuilder PB_Details(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_DfnBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_DfnBuilder" /> instance.</returns>
        public static PB_DfnBuilder PB_Dfn(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_DialogBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_DialogBuilder" /> instance.</returns>
        public static PB_DialogBuilder PB_Dialog(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_DirBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_DirBuilder" /> instance.</returns>
        [Obsolete("dir is obsolete in HTML5.")]
        public static PB_DirBuilder PB_Dir(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_DivBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_DivBuilder" /> instance.</returns>
        public static PB_DivBuilder PB_Div(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_DlBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_DlBuilder" /> instance.</returns>
        public static PB_DlBuilder PB_Dl(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_DtBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_DtBuilder" /> instance.</returns>
        public static PB_DtBuilder PB_Dt(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_EmBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_EmBuilder" /> instance.</returns>
        public static PB_EmBuilder PB_Em(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_EmbedBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_EmbedBuilder" /> instance.</returns>
        public static PB_EmbedBuilder PB_Embed(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_FieldsetBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_FieldsetBuilder" /> instance.</returns>
        public static PB_FieldsetBuilder PB_Fieldset(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_FieldsetTagBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_FieldsetTagBuilder" /> instance.</returns>
        public static PB_FieldsetTagBuilder PB_FieldsetTag(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_FigcaptionBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_FigcaptionBuilder" /> instance.</returns>
        public static PB_FigcaptionBuilder PB_Figcaption(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_FigureBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_FigureBuilder" /> instance.</returns>
        public static PB_FigureBuilder PB_Figure(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_FontBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_FontBuilder" /> instance.</returns>
        [Obsolete("font is obsolete in HTML5.")]
        public static PB_FontBuilder PB_Font(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_FooterBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_FooterBuilder" /> instance.</returns>
        public static PB_FooterBuilder PB_Footer(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_FormBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_FormBuilder" /> instance.</returns>
        public static PB_FormBuilder PB_Form(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_H1Builder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_H1Builder" /> instance.</returns>
        public static PB_H1Builder PB_H1(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_H2Builder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_H2Builder" /> instance.</returns>
        public static PB_H2Builder PB_H2(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_H3Builder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_H3Builder" /> instance.</returns>
        public static PB_H3Builder PB_H3(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_H4Builder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_H4Builder" /> instance.</returns>
        public static PB_H4Builder PB_H4(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_H5Builder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_H5Builder" /> instance.</returns>
        public static PB_H5Builder PB_H5(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_H6Builder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_H6Builder" /> instance.</returns>
        public static PB_H6Builder PB_H6(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_HeadBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_HeadBuilder" /> instance.</returns>
        public static PB_HeadBuilder PB_Head(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_HeaderBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_HeaderBuilder" /> instance.</returns>
        public static PB_HeaderBuilder PB_Header(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_HgroupBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_HgroupBuilder" /> instance.</returns>
        public static PB_HgroupBuilder PB_Hgroup(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_HrBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_HrBuilder" /> instance.</returns>
        public static PB_HrBuilder PB_Hr(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_IBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_IBuilder" /> instance.</returns>
        public static PB_IBuilder PB_I(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_IframeBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_IframeBuilder" /> instance.</returns>
        public static PB_IframeBuilder PB_Iframe(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_ImgBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_ImgBuilder" /> instance.</returns>
        public static PB_ImgBuilder PB_Img(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_InputBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_InputBuilder" /> instance.</returns>
        public static PB_InputBuilder PB_Input(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_InsBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_InsBuilder" /> instance.</returns>
        public static PB_InsBuilder PB_Ins(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_KbdBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_KbdBuilder" /> instance.</returns>
        public static PB_KbdBuilder PB_Kbd(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_LabelBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_LabelBuilder" /> instance.</returns>
        public static PB_LabelBuilder PB_Label(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_LegendBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_LegendBuilder" /> instance.</returns>
        public static PB_LegendBuilder PB_Legend(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_LegendTagBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_LegendTagBuilder" /> instance.</returns>
        public static PB_LegendTagBuilder PB_LegendTag(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_LiBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_LiBuilder" /> instance.</returns>
        public static PB_LiBuilder PB_Li(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_LinkBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_LinkBuilder" /> instance.</returns>
        public static PB_LinkBuilder PB_Link(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_MainBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_MainBuilder" /> instance.</returns>
        public static PB_MainBuilder PB_Main(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_MainTagBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_MainTagBuilder" /> instance.</returns>
        public static PB_MainTagBuilder PB_MainTag(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_MapBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_MapBuilder" /> instance.</returns>
        public static PB_MapBuilder PB_Map(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_MarkBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_MarkBuilder" /> instance.</returns>
        public static PB_MarkBuilder PB_Mark(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_MenuBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_MenuBuilder" /> instance.</returns>
        public static PB_MenuBuilder PB_Menu(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_MetaBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_MetaBuilder" /> instance.</returns>
        public static PB_MetaBuilder PB_Meta(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_MeterBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_MeterBuilder" /> instance.</returns>
        public static PB_MeterBuilder PB_Meter(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_NavBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_NavBuilder" /> instance.</returns>
        public static PB_NavBuilder PB_Nav(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_NoembedBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_NoembedBuilder" /> instance.</returns>
        [Obsolete("noembed is obsolete.")]
        public static PB_NoembedBuilder PB_Noembed(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_NoframesBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_NoframesBuilder" /> instance.</returns>
        [Obsolete("noframes is obsolete.")]
        public static PB_NoframesBuilder PB_Noframes(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_NoscriptBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_NoscriptBuilder" /> instance.</returns>
        public static PB_NoscriptBuilder PB_Noscript(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_ObjectBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_ObjectBuilder" /> instance.</returns>
        public static PB_ObjectBuilder PB_Object(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_OlBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_OlBuilder" /> instance.</returns>
        public static PB_OlBuilder PB_Ol(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_OptgroupBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_OptgroupBuilder" /> instance.</returns>
        public static PB_OptgroupBuilder PB_Optgroup(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_OptgroupTagBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_OptgroupTagBuilder" /> instance.</returns>
        public static PB_OptgroupTagBuilder PB_OptgroupTag(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_OptionBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_OptionBuilder" /> instance.</returns>
        public static PB_OptionBuilder PB_Option(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_OptionTagBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_OptionTagBuilder" /> instance.</returns>
        public static PB_OptionTagBuilder PB_OptionTag(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_OutputBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_OutputBuilder" /> instance.</returns>
        public static PB_OutputBuilder PB_Output(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_ParagraphBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_ParagraphBuilder" /> instance.</returns>
        public static PB_ParagraphBuilder PB_P(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_ParamBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_ParamBuilder" /> instance.</returns>
        public static PB_ParamBuilder PB_Param(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_PictureBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_PictureBuilder" /> instance.</returns>
        public static PB_PictureBuilder PB_Picture(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_PlaintextBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_PlaintextBuilder" /> instance.</returns>
        [Obsolete("plaintext is obsolete.")]
        public static PB_PlaintextBuilder PB_Plaintext(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_PreBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_PreBuilder" /> instance.</returns>
        public static PB_PreBuilder PB_Pre(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_ProgressBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_ProgressBuilder" /> instance.</returns>
        public static PB_ProgressBuilder PB_Progress(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_QBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_QBuilder" /> instance.</returns>
        public static PB_QBuilder PB_Q(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_RbBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_RbBuilder" /> instance.</returns>
        [Obsolete("rb is obsolete.")]
        public static PB_RbBuilder PB_Rb(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_RegionBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <param name="name">The logical region name to render.</param>
        /// <returns>A new <see cref="PB_RegionBuilder" /> instance.</returns>
        public static PB_RegionBuilder PB_RegionBuilder(this IHtmlHelper html, string name) => new(html.ViewContext.Writer, html, name);

        /// <summary>
        ///     Creates a <see cref="PB_RpBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_RpBuilder" /> instance.</returns>
        public static PB_RpBuilder PB_Rp(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_RtBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_RtBuilder" /> instance.</returns>
        public static PB_RtBuilder PB_Rt(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_RtcBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_RtcBuilder" /> instance.</returns>
        [Obsolete("rtc is obsolete.")]
        public static PB_RtcBuilder PB_Rtc(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_RubyBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_RubyBuilder" /> instance.</returns>
        public static PB_RubyBuilder PB_Ruby(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_SBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_SBuilder" /> instance.</returns>
        public static PB_SBuilder PB_S(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_SampBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_SampBuilder" /> instance.</returns>
        public static PB_SampBuilder PB_Samp(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_ScriptBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_ScriptBuilder" /> instance.</returns>
        public static PB_ScriptBuilder PB_Script(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_SearchBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_SearchBuilder" /> instance.</returns>
        public static PB_SearchBuilder PB_Search(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_SectionBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_SectionBuilder" /> instance.</returns>
        public static PB_SectionBuilder PB_Section(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_SelectBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_SelectBuilder" /> instance.</returns>
        public static PB_SelectBuilder PB_Select(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_SelectTagBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_SelectTagBuilder" /> instance.</returns>
        public static PB_SelectTagBuilder PB_SelectTag(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_SmallBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_SmallBuilder" /> instance.</returns>
        public static PB_SmallBuilder PB_Small(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_SmallBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_SmallBuilder" /> instance.</returns>
        public static PB_SmallBuilder PB_SmallTag(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_SourceBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_SourceBuilder" /> instance.</returns>
        public static PB_SourceBuilder PB_Source(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_SpanBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_SpanBuilder" /> instance.</returns>
        public static PB_SpanBuilder PB_Span(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_StrikeBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_StrikeBuilder" /> instance.</returns>
        [Obsolete("strike is obsolete.")]
        public static PB_StrikeBuilder PB_Strike(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_StrongBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_StrongBuilder" /> instance.</returns>
        public static PB_StrongBuilder PB_Strong(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_StyleBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_StyleBuilder" /> instance.</returns>
        public static PB_StyleBuilder PB_StyleTag(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_SubBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_SubBuilder" /> instance.</returns>
        public static PB_SubBuilder PB_Sub(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_SummaryBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_SummaryBuilder" /> instance.</returns>
        public static PB_SummaryBuilder PB_Summary(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_SupBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_SupBuilder" /> instance.</returns>
        public static PB_SupBuilder PB_Sup(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_TableBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_TableBuilder" /> instance.</returns>
        public static PB_TableBuilder PB_Table(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_TbodyBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_TbodyBuilder" /> instance.</returns>
        public static PB_TbodyBuilder PB_Tbody(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_TdBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_TdBuilder" /> instance.</returns>
        public static PB_TdBuilder PB_Td(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_TemplateBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_TemplateBuilder" /> instance.</returns>
        public static PB_TemplateBuilder PB_Template(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_TextareaBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_TextareaBuilder" /> instance.</returns>
        public static PB_TextareaBuilder PB_Textarea(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_TextareaTagBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_TextareaTagBuilder" /> instance.</returns>
        public static PB_TextareaTagBuilder PB_TextareaTag(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_TfootBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_TfootBuilder" /> instance.</returns>
        public static PB_TfootBuilder PB_Tfoot(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_ThBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_ThBuilder" /> instance.</returns>
        public static PB_ThBuilder PB_Th(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_TheadBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_TheadBuilder" /> instance.</returns>
        public static PB_TheadBuilder PB_Thead(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_TimeBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_TimeBuilder" /> instance.</returns>
        public static PB_TimeBuilder PB_TimeTag(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_TitleTagBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_TitleTagBuilder" /> instance.</returns>
        public static PB_TitleTagBuilder PB_TitleTag(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_TrBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_TrBuilder" /> instance.</returns>
        public static PB_TrBuilder PB_Tr(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_TrackBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_TrackBuilder" /> instance.</returns>
        public static PB_TrackBuilder PB_Track(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_TtBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_TtBuilder" /> instance.</returns>
        [Obsolete("tt is obsolete.")]
        public static PB_TtBuilder PB_Tt(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_UBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_UBuilder" /> instance.</returns>
        public static PB_UBuilder PB_U(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_UlBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_UlBuilder" /> instance.</returns>
        public static PB_UlBuilder PB_Ul(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_VarBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_VarBuilder" /> instance.</returns>
        public static PB_VarBuilder PB_Var(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_VideoBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_VideoBuilder" /> instance.</returns>
        public static PB_VideoBuilder PB_Video(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        /// <summary>
        ///     Creates a <see cref="PB_XmpBuilder" /> for the current Razor view.
        /// </summary>
        /// <param name="html">The Razor HTML helper that provides the view writer.</param>
        /// <returns>A new <see cref="PB_XmpBuilder" /> instance.</returns>
        [Obsolete("xmp is obsolete.")]
        public static PB_XmpBuilder PB_Xmp(this IHtmlHelper html) => new(html.ViewContext.Writer, html);

        #endregion
    }
}