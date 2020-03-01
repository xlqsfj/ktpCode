using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcs.WinForm.Models;
using KtpAcsMiddleware.Infrastructure.Utilities;

namespace KtpAcs.WinForm.UserControls
{
    public partial class KtpGridPager : UserControl
    { /// <summary>
      ///     列表数据加载方法(事件)
      /// </summary>
        public delegate void PagingEventHandler();

        private int _pageCount;
        private int _pageIndex = 1;
        private PagingEventHandler _pagingHandler;
        /// <summary>
        ///     每页显示行数
        /// </summary>
        public int PageSize { get; set; } = 15;
        public KtpGridPager()
        {
            InitializeComponent();
        }
        /// <summary>
        ///     总页数
        /// </summary>
        public int PageCount
        {
            get { return _pageCount; }
            set
            {
                _pageCount = value;
                if (_pagingHandler != null)
                {
                    SetRoleNavigatorState();
                }
            }
        }
        /// <summary>
        ///     翻页触发事件(列表数据加载方法)
        /// </summary>
        public PagingEventHandler PagingHandler
        {
            get { return _pagingHandler; }
            set
            {
                _pagingHandler = value;
                SetRoleNavigatorState();
            }
        }
        /// <summary>
        ///     当前页码
        /// </summary>
        public int PageIndex
        {
            get { return _pageIndex; }
            set
            {
                _pageIndex = value;
                if (_pagingHandler != null)
                {
                    _pagingHandler();
                    SetRoleNavigatorState();
                }
            }
        }
        private void navRefreshButton_Click(object sender, EventArgs e)
        {
            if (_pagingHandler != null)
            {
                PageIndex = 1;
            }
        }
        /// <summary>
        ///     设置各个控件的状态(禁用与启用)
        /// </summary>
        private void SetRoleNavigatorState()
        {
            navPageCount.Text = FormatHelper.GetIntString(_pageCount);
            navPageIndex.Text = FormatHelper.GetIntString(_pageIndex);
            if (_pageCount > 1)
            {
                if (_pageIndex == 1)
                {
                    navFirstPage.Enabled = false;
                    navPrePage.Enabled = false;
                    navNextPage.Enabled = true;
                    navLastPage.Enabled = true;
                }
                else if (_pageIndex == _pageCount)
                {
                    navFirstPage.Enabled = true;
                    navPrePage.Enabled = true;
                    navNextPage.Enabled = false;
                    navLastPage.Enabled = false;
                }
                else
                {
                    navFirstPage.Enabled = true;
                    navPrePage.Enabled = true;
                    navNextPage.Enabled = true;
                    navLastPage.Enabled = true;
                }
                navPageIndex.Enabled = true;
                navGoPageButton.Enabled = true;
            }
            else
            {
                navFirstPage.Enabled = false;
                navPrePage.Enabled = false;
                navNextPage.Enabled = false;
                navLastPage.Enabled = false;
                navPageIndex.Enabled = false;
                navGoPageButton.Enabled = false;
            }
        }

        private void navFirstPage_Click(object sender, EventArgs e)
        {
            PageIndex = 1;
        }

        private void navPrePage_Click(object sender, EventArgs e)
        {
            PageIndex = PageIndex - 1;
        }

        private void navNextPage_Click(object sender, EventArgs e)
        {
            PageIndex = PageIndex + 1;
        }

        private void navLastPage_Click(object sender, EventArgs e)
        {
            PageIndex = _pageCount;
        }

        /// <summary>
        ///     转到指定页
        /// </summary>
        private void navGoPageButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(navPageIndex.Text, out _pageIndex))
                {
                    if (_pageIndex < 1 || _pageIndex > _pageCount)
                    {
                        throw new PreValidationException("目标页超出范围");
                    }
                    _pagingHandler();
                    SetRoleNavigatorState();
                }
                else
                {
                    throw new PreValidationException("目标页必须为数字格式");
                }
            }
            catch (PreValidationException ex)
            {
                MessageHelper.Show(ex.Message);
            }
        }
    }
}
