﻿using CYQ.Data.Cache;



namespace CYQ.Data.Lock
{
    internal class RedisLock : DistributedLock
    {
        private static readonly RedisLock _instance = new RedisLock();
        private RedisLock() { }
        public static RedisLock Instance
        {
            get
            {
                return _instance;
            }
        }
        public override LockType LockType
        {
            get
            {
                return LockType.Redis;
            }
        }

        public override bool Lock(string key, int millisecondsTimeout)
        {
            return DistributedCache.Redis.Lock(key, millisecondsTimeout);
        }

        public override void UnLock(string key)
        {
            DistributedCache.Redis.UnLock(key);
        }
    }
}