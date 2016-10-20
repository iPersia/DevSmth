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
        public static readonly PictureTopicLoader Instance = new PictureTopicLoader();
        #endregion

        /// <summary>
        /// 
        /// </summary>
        private string _url = "http://m.newsmth.net/board/MyPhoto";

        /// <summary>
        /// 
        /// </summary>
        private LinkedList<PictureTopic> _pictureTopics = new LinkedList<PictureTopic>();

        /// <summary>
        /// 
        /// </summary>
        PictureTopicLoader()
        {
            this.IsWorking = false;
            Initialize();
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
        public void LoadNext()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        protected bool IsWorking
        {
            get;
            private set;
        }

        /// <summary>
        /// 
        /// </summary>
        private void Initialize()
        {
            this.FetchTopics(1);
        }

        #region Topic loading
        /// <summary>
        /// 
        /// </summary>
        private bool FetchTopics(int index)
        {
            try
            {
                //this._mutexFetchPage.WaitOne();
                if (index > 0 && this.IsWorking == false)
                {   
                    string url = this._url + "?p=" + index;
                    PageLoader pl = new PageLoader(url);
                    pl.PageLoaded += new EventHandler(TopicsPageLoader_PageLoaded);
                    pl.PageFailed += new EventHandler(TopicsPageLoader_PageFailed);
                    PageDispatcher.Instance.Add(pl);
                    this.IsWorking = true;
                    return true;
                }
                else
                {
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
                    else
                    {
                        this.IsWorking = false;
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
                this.IsWorking = false;
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
                foreach(Topic topic in topics)
                {
                    if (topic.Mode != TopicStatus.Top)
                    {
                        PageLoader pl = new PageLoader(topic.Uri);
                        pl.PageLoaded += new EventHandler(AriticlePageLoader_PageLoaded);
                        PageDispatcher.Instance.Add(pl);
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
                ///The work is done actually in here.
                this.IsWorking = false; 
            }
            catch (Exception exp)
            {
            }
            finally
            {
                this.IsWorking = false;
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
                    else
                    {
                        this.IsWorking = false;
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
            bwAriticleLoading.DoWork += new System.ComponentModel.DoWorkEventHandler(AriticleLoding_DoWork);
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
        private void AriticleLoding_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                BackgroundWorker bw = sender as BackgroundWorker;
                WebPage wp = e.Argument as WebPage;
                IList<Thread> threads = ThreadFactory.CreateThreads(wp, false);
                PictureTopic pt = new PictureTopic();
                pt.Title = SmthUtil.GetTopic(wp);
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
                    this._pictureTopics.AddLast(pt);
                }
            }
            catch (Exception exp)
            {
                int x = 1;
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
                ///The work is done actually in here.
                this.IsWorking = false;
            }
            catch (Exception exp)
            {
            }
            finally
            {
                this.IsWorking = false;
            }
        }
        #endregion
        #endregion
    }
}
