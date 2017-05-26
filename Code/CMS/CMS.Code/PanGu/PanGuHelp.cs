using PanGu;
using PanGu.Dict;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Code.PanGu
{
    public class PanGuHelp
    {

        #region 单例模式创建对象
        //单例模式创建对象
        private static PanGuHelp _panGuHelp = null;
        // Creates an syn object.
        private static readonly object SynObject = new object();
        PanGuHelp()
        {
        }

        public static PanGuHelp panGuHelp
        {
            get
            {
                // Double-Checked Locking
                if (null == _panGuHelp)
                {
                    lock (SynObject)
                    {
                        if (null == _panGuHelp)
                        {
                            _panGuHelp = new PanGuHelp();
                        }
                    }
                }
                return _panGuHelp;
            }
        }
        #endregion

        /// <summary>
        /// 生成分词
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public List<string> GenWords(string strs)
        {
            List<string> wordslst = new List<string>();
            ICollection<WordInfo> words = GetWords(strs);
            foreach (WordInfo wordInfo in words)
            {
                if (wordInfo == null)
                {
                    continue;
                }
                wordslst.Add(wordInfo.Word);
            }
            return wordslst;
        }

        /// <summary>
        /// 分词
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        private ICollection<WordInfo> GetWords(string strs)
        {
            global::PanGu.Match.MatchOptions Options = SetOptions();
            global::PanGu.Match.MatchParameter Parameters = SetParameters();
            Segment segment = new Segment();
            ICollection<WordInfo> words = segment.DoSegment(strs, Options, Parameters);
            return words;
        }
        private global::PanGu.Match.MatchOptions SetOptions()
        {
            global::PanGu.Match.MatchOptions Options = new global::PanGu.Match.MatchOptions();
            Options.FrequencyFirst = false;
            Options.FilterStopWords = true;
            Options.ChineseNameIdentify = true;
            Options.MultiDimensionality = true;
            Options.EnglishMultiDimensionality = false;
            Options.ForceSingleWord = false;
            Options.TraditionalChineseEnabled = false;
            Options.OutputSimplifiedTraditional = false;
            Options.UnknownWordIdentify = false;
            Options.FilterEnglish = false;
            Options.FilterNumeric = false;
            Options.IgnoreCapital = false;
            Options.EnglishSegment = false;
            Options.SynonymOutput = false;
            Options.WildcardOutput = false;
            Options.WildcardSegment = false;
            Options.CustomRule = false;

            return Options;
        }
        private global::PanGu.Match.MatchParameter SetParameters()
        {
            global::PanGu.Match.MatchParameter Parameters = new global::PanGu.Match.MatchParameter();

            Parameters.Redundancy = 0;
            Parameters.FilterEnglishLength = 0;
            Parameters.FilterNumericLength = 0;
            return Parameters;
        }

    }
}
