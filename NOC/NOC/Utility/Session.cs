using NOC.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NOC.Utility
{
   public class Session
    {
        #region session instance
        private static Session _instance;
        public static Session Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Session();
                return _instance;
            }
        }
        public Session() { }
        #endregion

        public String Token;
        public List<NotificationsModel> NotificationsModelList = new List<NotificationsModel>();
        public List<TransactionModel> ApplicationsOrTransactionsList = new List<TransactionModel>();
        public TransactionDetailsModel CurrentTransaction = new TransactionDetailsModel();
       
        public MenuItemsCountModel MenuItemsCountModelData { get; set; }
        public List<CommentsModel> CurerentTransactionCommentsList = new List<CommentsModel>();

    }
}
