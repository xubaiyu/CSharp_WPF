using ACMEControl.Entity;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ACMEControl.Model
{
    /// <summary>
    /// 树形控件数据的操作
    /// </summary>
    public class CameraTreeModel : ObservableObject
    {
        private static readonly Lazy<CameraTreeModel> lazy = new Lazy<CameraTreeModel>(() => new CameraTreeModel());

        public static CameraTreeModel Instance
        {
            get { return lazy.Value; }
        }

        private CameraTreeModel() { }

        /// <summary>
        /// 节点缓存
        /// </summary>
        private ObservableCollection<CameraTreeNode> cameraListCache = new ObservableCollection<CameraTreeNode>();
        private Dictionary<string, CameraTreeNode> dic = new Dictionary<string, CameraTreeNode>();
        private ObservableCollection<CameraTreeNode> tempCameraList = new ObservableCollection<CameraTreeNode>();
        /// <summary>
        /// 摄像机节点
        /// </summary>
        public ObservableCollection<CameraTreeNode> CameraList
        {
            get { return tempCameraList; }
            set { Set(() => CameraList, ref tempCameraList, value); }
        }

        /// <summary>
        /// 初始化树.每次需要更新树节点时候，需要调用此函数
        /// </summary>
        /// <param name="list">要传入的树列表</param>
        public void Init(ObservableCollection<CameraTreeNode> list)
        {
            cameraListCache.Clear();
            cameraListCache = list;
            CameraList = cameraListCache;
            lock (dic)
            {
                dic.Clear();
                UpdateDic(list);
            }
        }

        /// <summary>
        /// 当更新树形节点时候更新dic
        /// </summary>
        /// <param name="list"></param>
        private void UpdateDic(ObservableCollection<CameraTreeNode> list)
        {
            foreach (var item in list)
            {
                if (!dic.ContainsKey(item.GUID))
                {
                    dic[item.GUID] = item;
                    UpdateDic(item.SubNodeList);
                }
            }
        }

        /// <summary>
        /// 根据字符串查找内容
        /// </summary>
        /// <param name="searchText"></param>
        public void SearchContent(string searchText)
        {
            //没有搜索内容接默认原来的列表
            if (string.IsNullOrEmpty(searchText))
            {
                CameraList = cameraListCache;
                return;
            }

            lock (dic)
            {
                ObservableCollection<CameraTreeNode> tempCacheList = new ObservableCollection<CameraTreeNode>();
                Dictionary<string, CameraTreeNode> tempDic = new Dictionary<string, CameraTreeNode>();

                //查询符合条件的节点并开始克隆
                List<CameraTreeNode> selectedNodes = dic.Values.Where(n => n.CameraName.Contains(searchText)).ToList();

                foreach (CameraTreeNode node in selectedNodes)
                {
                    CloneNode(node, tempCacheList, tempDic);
                }

                //把查询到的节点列表显示出来
                CameraList = tempCacheList;
            }
        }

        private void CloneNode(CameraTreeNode node, ObservableCollection<CameraTreeNode> tempCacheList, Dictionary<string, CameraTreeNode> tempDic)
        {
            //根节点向上不在克隆
            if (node == null)
                return;

            //已经存在，说明克隆过了，兄弟节点的父节点不重复克隆
            if (tempDic.ContainsKey(node.GUID))
            {
                return;
            }

            CameraTreeNode tempNode = (CameraTreeNode)node.Clone();
            tempDic.Add(tempNode.GUID, tempNode);

            //是根节点就加载列表中以备显示
            if (node.Parent == null)
            {
                tempCacheList.Add(tempNode);
                return;
            }

            //强制克隆父节点
            CloneNode(node.Parent, tempCacheList, tempDic);

            //把当前节点添加到父节点的列表中，并且展开该节点的父节点
            tempNode.Parent = tempDic[node.Parent.GUID];
            tempNode.Parent.IsExpanded = true;
            tempNode.Parent.SubNodeList.Add(tempNode);
        }

        /// <summary>
        /// 节点删除
        /// </summary>
        /// <param name="node">要删除的节点</param>
        public void DeleteNode(CameraTreeNode node)
        {
            if (node == null)
                return;
            if (node.Parent == null)
            {
                CameraList.Remove(node);
                return;
            }
            node.SubNodeList.Clear();
            node.Parent.SubNodeList.Remove(node);
            dic.Remove(node.GUID);
        }

        /// <summary>
        /// 追加节点
        /// </summary>
        /// <param name="parentNode">父节点</param>
        /// <param name="node">要追加的节点</param>
        public void AppendNode(CameraTreeNode parentNode, CameraTreeNode node)
        {
            if (!dic.ContainsKey(node.GUID))
            {
                dic[node.GUID] = node;
            }
            if (parentNode == null)
            {
                node.Parent = null;
                CameraList.Add(node);

                return;
            }
            node.Parent = parentNode;
            if (parentNode.SubNodeList == null)
                parentNode.SubNodeList = new ObservableCollection<CameraTreeNode>();
            parentNode.SubNodeList.Add(node);
        }
    }
}
