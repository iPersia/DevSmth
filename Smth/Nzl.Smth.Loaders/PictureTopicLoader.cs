namespace Nzl.Smth.Loaders
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using Nzl.Smth.Datas;
    using Nzl.Smth.Utils;
    using Nzl.Web.Page;
    using Nzl.Web.Util;

    /// <summary>
    /// 
    /// </summary>
    public class PictureTopicLoader
    {
        #region Singleton
        /// <summary>
        /// 
        /// </summary>
        public static readonly PictureTopicLoader PictureInstance = new PictureTopicLoader("http://m.newsmth.net/board/picture");

        /// <summary>
        /// 
        /// </summary>
        public static readonly PictureTopicLoader PhotoInstance = new PictureTopicLoader("http://m.newsmth.net/board/myPhoto");

        /// <summary>
        /// 
        /// </summary>
        public static readonly PictureTopicLoader Instance = PictureInstance;
        #endregion

        /// <summary>
        /// 
        /// </summary>
        private string _url = "";

        /// <summary>
        /// 
        /// </summary>
        private LinkedList<PictureTopic> _pictureTopics = new LinkedList<PictureTopic>();

        /// <summary>
        /// 
        /// </summary>
        private Dictionary<string, PictureTopic> _dicPictureTopics = new Dictionary<string, PictureTopic>();

        /// <summary>
        /// 
        /// </summary>
        PictureTopicLoader(string url)
        {
            this._url = url;
            this.Initialize();
        }

        /// <summary>
        /// 
        /// </summary>
        public LinkedList<PictureTopic> PictureTopics
        {
            get
            {
                return this._pictureTopics;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        private void Initialize()
        {
            for (int i = 1; i < 2; i++)
            {
                this.FetchTopics(i);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void Add(PictureTopic pt)
        {
            lock (this._pictureTopics)
            {
                ///
                if (pt == null || this._dicPictureTopics.ContainsKey(pt.Url))
                {
                    return;
                }

                try
                {
                    this._dicPictureTopics.Add(pt.Url, pt);
                }
                catch { }

                if (this._pictureTopics.First == null || string.Compare(this._pictureTopics.First.Value.Url, pt.Url) < 0)
                {
                    this._pictureTopics.AddFirst(pt);
                    return;
                }

                if (this._pictureTopics.Last != null && string.Compare(this._pictureTopics.Last.Value.Url, pt.Url) > 0)
                {
                    this._pictureTopics.AddLast(pt);
                    return;
                }

                ///Insert into the sorted list.
                LinkedListNode<PictureTopic> ptNode = this._pictureTopics.First;
                while(ptNode != null)
                {
                    if (string.Compare(ptNode.Value.Url, pt.Url) < 0)
                    {
                        break;
                    }

                    ptNode = ptNode.Next;
                }

                this._pictureTopics.AddBefore(ptNode, pt);
            }
        }

        #region Topic loading
        /// <summary>
        /// 
        /// </summary>
        private bool FetchTopics(int index)
        {
            try
            {
                if (index > 0)
                {   
                    string url = this._url + "?p=" + index;
                    PageLoader pl = new PageLoader(url);
                    pl.PageLoaded += new EventHandler(TopicsPageLoader_PageLoaded);
                    pl.PageFailed += new EventHandler(TopicsPageLoader_PageFailed);
                    PageDispatcher.Instance.Add(pl);
                    return true;
                }

                return false;
            }
            finally
            {
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TopicsPageLoader_PageLoaded(object sender, EventArgs e)
        {
            lock (this)
            {
                PageLoader pl = sender as PageLoader;
                if (pl != null)
                {
                    WebPage wp = pl.GetResult() as WebPage;
                    if (wp != null && wp.IsGood)
                    {
                        this.TopicsPageLoaded(wp);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TopicsPageLoader_PageFailed(object sender, EventArgs e)
        {
            lock (this)
            {
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        private void TopicsPageLoaded(object pageInfor)
        {
            WebPage wp = pageInfor as WebPage;
            System.ComponentModel.BackgroundWorker bwTopicLoading = new System.ComponentModel.BackgroundWorker();
            bwTopicLoading.DoWork += new System.ComponentModel.DoWorkEventHandler(TopicLoding_DoWork);
            bwTopicLoading.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(TopicLoading_RunWorkerCompleted);
            bwTopicLoading.WorkerReportsProgress = true;
            bwTopicLoading.RunWorkerAsync(wp);
        }

        #region FetchPage
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TopicLoding_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                BackgroundWorker bw = sender as BackgroundWorker;
                WebPage wp = e.Argument as WebPage;
                IList<Topic> topics = TopicFactory.CreateTopics(wp);
#if (DEBUG)
                int counter = 0;
#endif
                foreach (Topic topic in topics)
                {
                    if (topic.Mode != TopicStatus.Top)
                    {
                        PageLoader pl = new PageLoader(topic.Uri);
                        pl.PageLoaded += new EventHandler(AriticlePageLoader_PageLoaded);
                        PageDispatcher.Instance.Add(pl);
#if (DEBUG)
                        if (counter++ > 2)
                        {
                        //    break;
                        }
#endif
                    }                    
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TopicLoading_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
            }
            catch (Exception exp)
            {
            }
            finally
            {
            }
        }
        #endregion
        #endregion

        #region Ariticle loading
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AriticlePageLoader_PageLoaded(object sender, EventArgs e)
        {
            lock (this)
            {
                PageLoader pl = sender as PageLoader;
                if (pl != null)
                {
                    WebPage wp = pl.GetResult() as WebPage;
                    if (wp != null && wp.IsGood)
                    {
                        this.AriticlePageLoaded(wp);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        private void AriticlePageLoaded(object pageInfor)
        {
            WebPage wp = pageInfor as WebPage;
            System.ComponentModel.BackgroundWorker bwAriticleLoading = new System.ComponentModel.BackgroundWorker();
            bwAriticleLoading.DoWork += new System.ComponentModel.DoWorkEventHandler(AriticleLoading_DoWork);
            bwAriticleLoading.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(AriticleLoading_RunWorkerCompleted);
            bwAriticleLoading.WorkerReportsProgress = true;
            bwAriticleLoading.RunWorkerAsync(wp);
        }

        #region FetchPage
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AriticleLoading_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                BackgroundWorker bw = sender as BackgroundWorker;
                WebPage wp = e.Argument as WebPage;
                IList<Thread> threads = ThreadFactory.CreateThreads(wp, false);
                PictureTopic pt = new PictureTopic();
                pt.Title = SmthUtil.GetTopic(wp);
                pt.Url = wp.URL;
                foreach (Thread thread in threads)
                {
                    if (thread.ImageUrls != null)
                    {
                        foreach (string url in thread.ImageUrls)
                        {
                            string largeImageUrl = url.Replace("/middle", "");
                            Image image = CommonUtil.GetWebImage(largeImageUrl);
                            if (image != null)
                            {
                                pt.PictureUrls.Add(largeImageUrl);
                            }
                        }
                    }
                }

                if (pt.PictureUrls.Count > 0)
                {
                    this.Add(pt);
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AriticleLoading_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
            }
            catch (Exception exp)
            {
            }
            finally
            {
            }
        }
        #endregion
        #endregion
    }
}
