﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jmILRL.DAL
{
    /// <summary>
    /// 
    /// </summary>
    public class FBT
    {
        private String _id;

        public String ID {
            get {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        /// <summary>
        /// sn
        /// </summary>
        public String serialNumber { get; set; }
        /// <summary>
        /// 批次号
        /// </summary>
        public String batchNumber { get; set; }
        /// <summary>
        /// 工号
        /// </summary>
        public String staff { get; set; }

        public float[] IL { get; set; }

        public float[] RL { get; set; }
        /// <summary>
        /// 最大和最小的差值
        /// </summary>
        public float[] DRL { get; set; }
        /// <summary>
        /// 波长
        /// </summary>
        public int[] wave { get; set; }
        /// <summary>
        /// 端口类型
        /// </summary>
        public String PortType { get; set; }

        private int _level = 0;
        /// <summary>
        /// 等级:0-不合格，1-合格。默认合格
        /// </summary>
        public int Level {
            get { return _level; }
            set { this._level = value; }
        }

        /// <summary>
        /// 默认构造函数，IL、RL均=4
        /// </summary>
        public FBT() {
            IL = new float[6];
            RL = new float[6];
            wave = new int[6];
            DRL = new float[6];
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="n">IL、RL数组列数</param>
        public FBT(int n) {
            IL = new float[n];
            RL = new float[n];
            wave = new int[n];
            DRL = new float[n];
        }

    }
}
