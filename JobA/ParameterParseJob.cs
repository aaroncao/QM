﻿using Common.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using QM.Common;
using System.Threading;
using System.ComponentModel;

namespace JobA {
    [Description("参数解析示例")]
    [ParameterType(typeof(Parameter))]
    public class ParameterParseJob : IJob {

        public static ILog Log = LogManager.GetLogger(typeof(ParameterParseJob));
        public void Execute(IJobExecutionContext context) {
            var dataMap = context.JobDetail.JobDataMap;
            //if (dataMap.ContainsKey("int")) {
            //    var pInt = dataMap.GetIntValue("int");
            //    Console.WriteLine("1 JobA Parameter {0}", pInt);
            //} else {
            //    Log.Error("缺少参数 int, 未执行");
            //    throw new JobExecutionException("缺少参数");
            //}

            var p = dataMap.Parse<Parameter>();
            Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{0}", p.Name, p.Birthday, p.Score, p.Grade, p.PreScore);


            Thread.Sleep(TimeSpan.FromMinutes(3));
        }
    }
}
