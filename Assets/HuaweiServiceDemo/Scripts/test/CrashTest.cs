﻿using System.Security.Cryptography;
using HuaweiService;
using HuaweiService.crash;
using UnityEngine;
using System;
using UnityEngine.Diagnostics;
using Exception = System.Exception;
using System.Runtime.InteropServices;

namespace HuaweiServiceDemo
{
    public class CrashTest : Test<CrashTest>
    {
        public const int DEBUG = 3;
        public const int ERROR = 6;
        public const int INFO = 4;
        public const int WARN = 5;
        
        public override void RegisterEvent(TestEvent registerEvent)
        {
            registerEvent("enableCrashCollection(true)", () => SetCrashCollection(true));
            registerEvent("enableCrashCollection(false)", () => SetCrashCollection(false));
            registerEvent("JAVA crash", SetTestIt);
            registerEvent("setUserId(String userId)", () => SetUserId("TestUserIdz"));
            registerEvent("setCustomKey(String key, String value)", () => SetCustomKey("stringKey", "world"));
            registerEvent("setCustomKey(String key, boolean value)", () => SetCustomKey("booleanKey", false));
            registerEvent("setCustomKey(String key, double value)", () => SetCustomKey("doubleKey", 1.1));
            registerEvent("setCustomKey(String key, float value)", () => SetCustomKey("floatKey", 1.1f));
            registerEvent("setCustomKey(String key, int value)", () => SetCustomKey("intKey", 0));
            registerEvent("setCustomKey(String key, long value)", () => SetCustomKey("longKey", 11L));
            registerEvent("log(String message)", () => Setlog("set info log"));
            registerEvent("log(int level, String message)", () => Setlog(DEBUG, "set debug log."));
        }
        public void SetCrashCollection(bool isCollection)
        {
            if (isCollection == true)
            {
                AGConnectCrash.getInstance().enableCrashCollection(true);
                TestTip.Inst.ShowText("upload crash collection");
            }
            else
            {
                AGConnectCrash.getInstance().enableCrashCollection(false);
                TestTip.Inst.ShowText("do not upload crash collection");
            }
        }
        
        public void SetTestIt()
        {
            TestTip.Inst.ShowText("create crash");
            AndroidJavaClass jc = new AndroidJavaClass("com.hms.hms_analytic_activity.HmsAnalyticActivity");
            jc.CallStatic("main");
        }
        
        public void SetUserId(string userid)
        {
            AGConnectCrash.getInstance().setUserId(userid);
            TestTip.Inst.ShowText($"set user id: {userid}");
        }

        public void SetCustomKey(string key, string value)
        {
            AGConnectCrash.getInstance().setCustomKey(key, value);
            TestTip.Inst.ShowText($"set key: {key}," + $"set string value: {value}");
        }
        
        public void SetCustomKey(string key, bool value)
        {
            AGConnectCrash.getInstance().setCustomKey(key, value);
            TestTip.Inst.ShowText($"set key: {key}," + $"set bool value: {value}");
        }
        public void SetCustomKey(string key, double value)
        {
            AGConnectCrash.getInstance().setCustomKey(key, value);
            TestTip.Inst.ShowText($"set key: {key}," + $"set double value: {value}");
        }
        public void SetCustomKey(string key, float value)
        {
            AGConnectCrash.getInstance().setCustomKey(key, value);
            TestTip.Inst.ShowText($"set key: {key}," + $"set float value: {value}");
        }
        public void SetCustomKey(string key, int value)
        {
            AGConnectCrash.getInstance().setCustomKey(key, value);
            TestTip.Inst.ShowText($"set key: {key}," + $"set int value: {value}");
        }
        public void SetCustomKey(string key, long value)
        {
            AGConnectCrash.getInstance().setCustomKey(key, value);
            TestTip.Inst.ShowText($"set key: {key}," + $"set long value: {value}");
        }
        public void Setlog(string log)
        {
            AGConnectCrash.getInstance().log(log);
            TestTip.Inst.ShowText($"log message: {log}");
        }
        public void Setlog(int level, string log)
        {
            AGConnectCrash.getInstance().log(level, log);
            TestTip.Inst.ShowText($"set log lever: {level}," + $"log message: {log}");
        }
    }
}