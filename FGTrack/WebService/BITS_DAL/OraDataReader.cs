﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using Oracle.DataAccess.Client;

namespace HTN.BITS.DAL
{
    public sealed class OraDataReader : IDisposable
    {
        //private static readonly OraDataReader instance;
        [ThreadStatic]
        static OraDataReader instance = null;


        private OracleDataReader oraReader;

        private OraDataReader()
        {
            IsReleased = false;
        }

        public bool IsReleased { get; private set; }

        static OraDataReader()
        {
            instance = new OraDataReader();
        }

        public static OraDataReader Instance
        {
            get
            {
                if (instance == null) instance = new OraDataReader();
                return instance;
            }
        }

        public OracleDataReader OraReader
        {
            get
            {
                return oraReader;
            }
            set
            {
                oraReader = value;
            }
        }

        public bool HasRows
        {
            get
            {
                return this.oraReader.HasRows;
            }
        }

        private int GetOrdinal(string fieldName)
        {
            return this.oraReader.GetOrdinal(fieldName);
        }

        public bool IsDBNull(string fieldName)
        {
            return this.oraReader.IsDBNull(GetOrdinal(fieldName));
        }

        public object GetValue(string fieldName)
        {
            return this.oraReader.GetValue(GetOrdinal(fieldName));
        }

        public DateTime GetDateTime(string fieldName)
        {
            return this.oraReader.GetDateTime(GetOrdinal(fieldName));
        }

        public string GetString(string fieldName)
        {
            try
            {
                int fieldIndex = GetOrdinal(fieldName);
                if (!this.oraReader.IsDBNull(fieldIndex))
                {
                    return this.oraReader.GetString(fieldIndex);
                }
                else
                {
                    return "";
                }
            }
            catch
            {
                return "";
            }
        }

        public int GetInteger(string fieldName)
        {
            try
            {
                int fieldIndex = GetOrdinal(fieldName);
                if (!this.oraReader.IsDBNull(fieldIndex))
                {
                    return Convert.ToInt32(this.oraReader.GetValue(fieldIndex), NumberFormatInfo.InvariantInfo);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public double GetDouble(string fieldName)
        {
            try
            {
                int fieldIndex = GetOrdinal(fieldName);
                if (!this.oraReader.IsDBNull(fieldIndex))
                {
                    return Convert.ToDouble(this.oraReader.GetValue(fieldIndex), NumberFormatInfo.InvariantInfo);
                }
                else
                {
                    return 0.0D;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public decimal GetDecimal(string fieldName)
        {
            try
            {
                int fieldIndex = GetOrdinal(fieldName);
                if (!this.oraReader.IsDBNull(fieldIndex))
                {
                    return Convert.ToDecimal(this.oraReader.GetValue(fieldIndex), NumberFormatInfo.InvariantInfo);
                }
                else
                {
                    return 0M;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Close()
        {
            this.oraReader.Close();
            Release();
        }

        private void Release()
        {
            IsReleased = true;
            this.oraReader.Dispose();
            this.oraReader = null;
            OraDataReader.instance = null;
        }


        #region IDisposable Members

        void IDisposable.Dispose() { Release(); }

        #endregion
    }
}
