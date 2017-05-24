using CMS.Application.WebManage;
using CMS.Code;
using CMS.Domain.Entity.WebManage;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.PanGu;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Comm
{
    public class LucenceHelp
    {
        private static string PANGUXML = Configs.GetValue("PanguXml");
        private static string PANGUDICPATH = Configs.GetValue("PanguDicPath");
        private static string LUCENCEINDEXPATH = Configs.GetValue("LucenceIndexPath");
        private static DirectoryInfo INDEX_DIR;
        private static Analyzer analyzer = new PanGuAnalyzer();

        static LucenceHelp()
        {
            PANGUXML = FileHelper.MapPath(PANGUXML);
            PANGUDICPATH = FileHelper.MapPath(PANGUDICPATH);
            LUCENCEINDEXPATH = FileHelper.MapPath(LUCENCEINDEXPATH);
            //定义盘古分词的xml引用路径
            PanGu.Segment.Init(PANGUXML);

        }

        /// <summary>
        /// 根据网站id创建内容索引
        /// </summary>
        public static void CreateIndex(string wenSiteIds)
        {
            if (!string.IsNullOrEmpty(wenSiteIds))
            {
                WebSiteApp webSiteApp = new WebSiteApp();
                ContentApp contentApp = new ContentApp();
                WebSiteEntity webSite = webSiteApp.GetForm(wenSiteIds);
                if (webSite != null)
                {
                    LUCENCEINDEXPATH = string.Format(LUCENCEINDEXPATH, webSite.ShortName);
                    INDEX_DIR = new DirectoryInfo(LUCENCEINDEXPATH);
                    List<ContentEntity> contents = contentApp.GetListByWebSiteId(wenSiteIds);

                    IndexWriter iw = new IndexWriter(Lucene.Net.Store.FSDirectory.Open(INDEX_DIR), analyzer, true, IndexWriter.MaxFieldLength.LIMITED);
                    int i = 0;
                    foreach (ContentEntity content in contents)
                    {
                        Document doc = new Document();
                        if (content.Id != null)
                        {
                            doc.Add(new Field("Id", content.Id, Field.Store.YES, Field.Index.ANALYZED));
                            if (content.FullName != null)
                                doc.Add(new Field("FullName", content.FullName, Field.Store.YES, Field.Index.ANALYZED));
                            if (content.Author != null)
                                doc.Add(new Field("Author", content.Author, Field.Store.YES, Field.Index.ANALYZED));
                            if (content.Content != null)
                                doc.Add(new Field("Content", content.Content, Field.Store.YES, Field.Index.ANALYZED));
                        }
                        iw.AddDocument(doc);
                    }
                    iw.Commit();
                    iw.Optimize();
                    iw.Dispose();
                }
            }
        }


        /// <summary>
        /// 根据网站id创建内容索引
        /// </summary>
        public static void CreateIndex(string wenSiteIds, string wenSiteShortName)
        {
            try
            {
                if (!new WebSiteConfigApp().IsSearch(wenSiteIds))
                {
                    throw new Exception("该站点未启用全站搜索功能！");
                }
                if (!string.IsNullOrEmpty(wenSiteShortName))
                {
                    ContentApp contentApp = new ContentApp();
                    LUCENCEINDEXPATH = string.Format(LUCENCEINDEXPATH, wenSiteShortName);
                    INDEX_DIR = new DirectoryInfo(LUCENCEINDEXPATH);
                    List<ContentEntity> contents = contentApp.GetListByWebSiteId(wenSiteIds);

                    using (IndexWriter iw = new IndexWriter(Lucene.Net.Store.FSDirectory.Open(INDEX_DIR), analyzer, true, IndexWriter.MaxFieldLength.LIMITED))
                    {
                        int i = 0;
                        foreach (ContentEntity content in contents)
                        {
                            Document doc = new Document();
                            if (content.Id != null)
                            {
                                doc.Add(new Field("Id", content.Id, Field.Store.YES, Field.Index.ANALYZED));
                                if (content.FullName != null)
                                    doc.Add(new Field("FullName", content.FullName, Field.Store.YES, Field.Index.ANALYZED));
                                if (content.Author != null)
                                    doc.Add(new Field("Author", content.Author, Field.Store.YES, Field.Index.ANALYZED));
                                if (content.Content != null)
                                    doc.Add(new Field("Content", content.Content, Field.Store.YES, Field.Index.ANALYZED));
                            }
                            iw.AddDocument(doc);
                        }
                        iw.Commit();
                        iw.Optimize();
                        iw.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据网站ID和关键字查询结果
        /// </summary>
        /// <param name="wenSiteIds"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public static List<ContentEntity> Search(string wenSiteIds, string keyword)
        {
            List<ContentEntity> mdoels = new List<ContentEntity>();
            if (!string.IsNullOrEmpty(wenSiteIds))
            {
                WebSiteApp webSiteApp = new WebSiteApp();
                WebSiteEntity webSite = webSiteApp.GetForm(wenSiteIds);
                if (webSite != null)
                {
                    LUCENCEINDEXPATH = string.Format(LUCENCEINDEXPATH, webSite.ShortName);
                    INDEX_DIR = new DirectoryInfo(LUCENCEINDEXPATH);
                    BooleanQuery bQuery = new BooleanQuery();

                    using (IndexSearcher searcher = new IndexSearcher(FSDirectory.Open(INDEX_DIR), true))
                    {
                        QueryParser parseFullName = new QueryParser(Lucene.Net.Util.Version.LUCENE_30, "FullName", analyzer);
                        Query query = parseFullName.Parse(keyword);
                        bQuery.Add(query, Occur.SHOULD);

                        QueryParser parseAuthor = new QueryParser(Lucene.Net.Util.Version.LUCENE_30, "Author", analyzer);
                        Query queryAuthor = parseAuthor.Parse(keyword);
                        bQuery.Add(queryAuthor, Occur.SHOULD);

                        QueryParser parseContent = new QueryParser(Lucene.Net.Util.Version.LUCENE_30, "Content", analyzer);
                        Query queryContent = parseContent.Parse(keyword);
                        bQuery.Add(queryContent, Occur.SHOULD);

                        TopDocs tds = searcher.Search(bQuery, Int32.MaxValue);
                        List<string> ids = new List<string>();
                        foreach (ScoreDoc sd in tds.ScoreDocs)
                        {
                            Document doc = searcher.Doc(sd.Doc);
                            ids.Add(doc.Get("Id"));
                        }
                        if (ids != null && ids.Count > 0)
                        {
                            ContentApp contentApp = new ContentApp();
                            mdoels = contentApp.GetLists(m => ids.Contains(m.Id));
                        }
                        searcher.Dispose();
                    }
                }
            }
            return mdoels;
        }

        /// <summary>
        /// 根据网站ID和关键字查询结果
        /// </summary>
        /// <param name="wenSiteIds"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public static List<ContentEntity> SearchByShortName(string wenSiteShortName, string keyword)
        {
            List<ContentEntity> mdoels = new List<ContentEntity>();
            if (!string.IsNullOrEmpty(wenSiteShortName))
            {
                LUCENCEINDEXPATH = string.Format(LUCENCEINDEXPATH, wenSiteShortName);
                INDEX_DIR = new DirectoryInfo(LUCENCEINDEXPATH);
                BooleanQuery bQuery = new BooleanQuery();

                using (IndexSearcher searcher = new IndexSearcher(FSDirectory.Open(INDEX_DIR), true))
                {
                    QueryParser parseFullName = new QueryParser(Lucene.Net.Util.Version.LUCENE_30, "FullName", analyzer);
                    Query query = parseFullName.Parse(keyword);
                    bQuery.Add(query, Occur.SHOULD);

                    QueryParser parseAuthor = new QueryParser(Lucene.Net.Util.Version.LUCENE_30, "Author", analyzer);
                    Query queryAuthor = parseAuthor.Parse(keyword);
                    bQuery.Add(queryAuthor, Occur.SHOULD);

                    QueryParser parseContent = new QueryParser(Lucene.Net.Util.Version.LUCENE_30, "Content", analyzer);
                    Query queryContent = parseContent.Parse(keyword);
                    bQuery.Add(queryContent, Occur.SHOULD);

                    TopDocs tds = searcher.Search(bQuery, Int32.MaxValue);
                    List<string> ids = new List<string>();
                    foreach (ScoreDoc sd in tds.ScoreDocs)
                    {
                        Document doc = searcher.Doc(sd.Doc);
                        ids.Add(doc.Get("Id"));
                    }
                    if (ids != null && ids.Count > 0)
                    {
                        ContentApp contentApp = new ContentApp();
                        mdoels = contentApp.GetLists(m => ids.Contains(m.Id));
                    }
                    searcher.Dispose();
                }
            }
            return mdoels;
        }
        /// <summary>
        /// 根据网站ID和关键字查询结果
        /// </summary>
        /// <param name="wenSiteIds"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public static IQueryable<ContentEntity> SearchByShortNameIq(string wenSiteShortName, string keyword)
        {
            IQueryable<ContentEntity> mdoels = null;
            if (!string.IsNullOrEmpty(wenSiteShortName))
            {
                LUCENCEINDEXPATH = string.Format(LUCENCEINDEXPATH, wenSiteShortName);
                INDEX_DIR = new DirectoryInfo(LUCENCEINDEXPATH);
                BooleanQuery bQuery = new BooleanQuery();

                using (IndexSearcher searcher = new IndexSearcher(FSDirectory.Open(INDEX_DIR), true))
                {
                    QueryParser parseFullName = new QueryParser(Lucene.Net.Util.Version.LUCENE_30, "FullName", analyzer);
                    Query query = parseFullName.Parse(keyword);
                    bQuery.Add(query, Occur.SHOULD);

                    QueryParser parseAuthor = new QueryParser(Lucene.Net.Util.Version.LUCENE_30, "Author", analyzer);
                    Query queryAuthor = parseAuthor.Parse(keyword);
                    bQuery.Add(queryAuthor, Occur.SHOULD);

                    QueryParser parseContent = new QueryParser(Lucene.Net.Util.Version.LUCENE_30, "Content", analyzer);
                    Query queryContent = parseContent.Parse(keyword);
                    bQuery.Add(queryContent, Occur.SHOULD);

                    TopDocs tds = searcher.Search(bQuery, Int32.MaxValue);
                    List<string> ids = new List<string>();
                    foreach (ScoreDoc sd in tds.ScoreDocs)
                    {
                        Document doc = searcher.Doc(sd.Doc);
                        ids.Add(doc.Get("Id"));
                    }
                    if (ids != null && ids.Count > 0)
                    {
                        ContentApp contentApp = new ContentApp();
                        mdoels = contentApp.GetListsIq(m => ids.Contains(m.Id));
                    }
                    searcher.Dispose();
                }
            }
            return mdoels;
        }
    }
}
