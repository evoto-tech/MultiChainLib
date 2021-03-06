﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MultiChainLib.Model;
using Newtonsoft.Json;

namespace MultiChainLib.Client
{
    public class MultiChainClient
    {
        public MultiChainClient(string hostname, int port, bool useSsl, string username, string password,
            string chainName, string chainKey = null)
        {
            Hostname = hostname;
            Port = port;
            UseSsl = useSsl;
            Username = username;
            Password = password;
            ChainName = chainName;
            ChainKey = chainKey;
        }

        private string Hostname { get; }
        private int Port { get; }
        private bool UseSsl { get; }
        private string ChainName { get; }
        private string ChainKey { get; }
        private string Username { get; }
        private string Password { get; }

        private string ServiceUrl
        {
            get
            {
                var protocol = "https";
                if (!UseSsl)
                    protocol = "http";
                return $"{protocol}://{Hostname}:{Port}/";
            }
        }

        public bool HasCredentials => !string.IsNullOrEmpty(Username);

        public event EventHandler<EventArgs<JsonRpcRequest>> Executing;

        public Task<JsonRpcResponse<List<PeerResponse>>> GetPeerInfoAsync()
        {
            return ExecuteAsync<List<PeerResponse>>("getpeerinfo", 0);
        }

        public Task<JsonRpcResponse<GetInfoResponse>> GetInfoAsync()
        {
            return ExecuteAsync<GetInfoResponse>("getinfo", 0);
        }

        // only supported by PBJ Cloud...
        public Task<JsonRpcResponse<GetServerInfoResponse>> GetServerInfoAsync()
        {
            return ExecuteAsync<GetServerInfoResponse>("getserverinfo", 0);
        }

        public Task<JsonRpcResponse<string>> SendWithMetadataAsync(string address, string assetName, decimal amount,
            byte[] dataHex)
        {
            var theAmount = new Dictionary<string, object> {[assetName] = amount};
            return ExecuteAsync<string>("sendwithmetadata", 0, address, theAmount, FormatHex(dataHex));
        }

        public Task<JsonRpcResponse<string>> SendToAddressAsync(string address, string assetName, decimal amount,
            string comment = null,
            string commentTo = null)
        {
            var theAmount = new Dictionary<string, object> {[assetName] = amount};
            return ExecuteAsync<string>("sendtoaddress", 0, address, theAmount, comment ?? string.Empty,
                commentTo ?? string.Empty);
        }

        public Task<JsonRpcResponse<string>> SendWithMetadataFromAsync(string fromAddress, string toAddress,
            string assetName, decimal amount, byte[] dataHex)
        {
            var theAmount = new Dictionary<string, object> {[assetName] = amount};
            return ExecuteAsync<string>("sendwithmetadatafrom", 0, fromAddress, toAddress, theAmount, FormatHex(dataHex));
        }

        public Task<JsonRpcResponse<string>> SendAssetToAddressAsync(string address, string assetName, decimal quantity,
            int nativeAmount = 0, string comment = null, string commentTo = null)
        {
            return ExecuteAsync<string>("sendassettoaddress", 0, address, assetName, quantity, nativeAmount,
                comment ?? string.Empty, commentTo ?? string.Empty);
        }

        public Task<JsonRpcResponse<string>> SendAssetFromAsync(string fromAddress, string toAddress, string assetName,
            decimal quantity,
            int nativeAmount = 0, string comment = null, string commentTo = null)
        {
            return ExecuteAsync<string>("sendassetfrom", 0, fromAddress, toAddress, assetName, quantity, nativeAmount,
                comment ?? string.Empty, commentTo ?? string.Empty);
        }

        public Task<JsonRpcResponse<bool>> GetGenerateAsync()
        {
            return ExecuteAsync<bool>("getgenerate", 0);
        }

        public Task<JsonRpcResponse<string>> SetGenerateAsync(bool generate)
        {
            return ExecuteAsync<string>("setgenerate", 0, generate);
        }


        public Task<JsonRpcResponse<int>> GetHashesPerSecAsync()
        {
            return ExecuteAsync<int>("gethashespersec", 0);
        }

        public Task<JsonRpcResponse<MiningInfoResponse>> GetMiningInfoAsync()
        {
            return ExecuteAsync<MiningInfoResponse>("getmininginfo", 0);
        }

        public Task<JsonRpcResponse<string>> GetBestBlockHashAsync()
        {
            return ExecuteAsync<string>("getbestblockhash", 0);
        }

        public Task<JsonRpcResponse<int>> GetBlockCountAsync()
        {
            return ExecuteAsync<int>("getblockcount", 0);
        }

        public Task<JsonRpcResponse<BlockchainInfoResponse>> GetBlockchainInfoAsync()
        {
            return ExecuteAsync<BlockchainInfoResponse>("getblockchaininfo", 0);
        }

        public Task<JsonRpcResponse<decimal>> GetDifficultyAsync()
        {
            return ExecuteAsync<decimal>("getdifficulty", 0);
        }

        public Task<JsonRpcResponse<List<ChainTipResponse>>> GetChainTipsAsync()
        {
            return ExecuteAsync<List<ChainTipResponse>>("getchaintips", 0);
        }

        public Task<JsonRpcResponse<List<object>>> GetRawMempoolAsync()
        {
            return ExecuteAsync<List<object>>("getrawmempool", 0);
        }

        public Task<JsonRpcResponse<MempoolResponse>> GetRawMempoolVerboseAsync()
        {
            return ExecuteAsync<MempoolResponse>("getrawmempool", 0, true);
        }

        public Task<JsonRpcResponse<MempoolInfoResponse>> GetMempoolInfoAsync()
        {
            return ExecuteAsync<MempoolInfoResponse>("getmempoolinfo", 0);
        }

        public Task<JsonRpcResponse<string>> GetBlockHashAsync(int block)
        {
            return ExecuteAsync<string>("getblockhash", 0, block);
        }

        public Task<JsonRpcResponse<string>> GetBlockAsync(string hash)
        {
            return ExecuteAsync<string>("getblock", 0, hash, false);
        }

        public Task<JsonRpcResponse<BlockResponse>> GetBlockVerboseAsync(string hash)
        {
            return ExecuteAsync<BlockResponse>("getblock", 0, hash, true);
        }

        public static byte[] ParseHexString(string hex)
        {
            var bs = new List<byte>();
            for (var index = 0; index < hex.Length; index += 2)
                bs.Add(byte.Parse(hex.Substring(index, 2), NumberStyles.HexNumber));
            return bs.ToArray();
        }

        public Task<JsonRpcResponse<List<ListPermissionsResponse>>> ListPermissions(BlockchainPermissions permissions)
        {
            var permissionsAsString = FormatPermissions(permissions);
            return ExecuteAsync<List<ListPermissionsResponse>>("listpermissions", 0, permissionsAsString);
        }

        public Task<JsonRpcResponse<string>> IssueAsync(string issueAddress, string assetName, int quantity,
            decimal units)
        {
            return ExecuteAsync<string>("issue", 0, issueAddress, assetName, quantity, units);
        }

        public Task<JsonRpcResponse<string>> IssueAsync(string issueAddress, object assetParams, int quantity,
            decimal units)
        {
            return ExecuteAsync<string>("issue", 0, issueAddress, assetParams, quantity, units);
        }

        public Task<JsonRpcResponse<string>> IssueFromAsync(string fromAddress, string toAddress, string assetName,
            int quantity, decimal units)
        {
            return ExecuteAsync<string>("issuefrom", 0, fromAddress, toAddress, assetName, quantity, units);
        }

        public Task<JsonRpcResponse<string>> IssueFromAsync(string fromAddress, string issueAddress, object assetParams,
            int quantity,
            decimal units)
        {
            return ExecuteAsync<string>("issuefrom", 0, fromAddress, issueAddress, assetParams, quantity, units);
        }

        public Task<JsonRpcResponse<string>> IssueMoreAsync(string issueAddress, string assetName, int quantity)
        {
            return ExecuteAsync<string>("issuemore", 0, issueAddress, assetName, quantity);
        }

        public Task<JsonRpcResponse<string>> IssueMoreFromAsync(string fromAddress, string toAddress, string assetName,
            int quantity)
        {
            return ExecuteAsync<string>("issuemorefrom", 0, fromAddress, toAddress, assetName, quantity);
        }

        public Task<JsonRpcResponse<List<AssetResponse>>> ListAssetsAsync()
        {
            return ExecuteAsync<List<AssetResponse>>("listassets", 0);
        }

        public Task<JsonRpcResponse<string>> GrantAsync(IEnumerable<string> addresses, BlockchainPermissions permissions,
            decimal nativeAmount = 0M, string comment = null,
            string commentTo = null, int startBlock = 0, int endBlock = 0)
        {
            var stringifiedAddresses = StringifyValues(addresses);
            var permissionsAsString = FormatPermissions(permissions);
            return ExecuteAsync<string>("grant", 0, stringifiedAddresses, permissionsAsString);
        }

        public Task<JsonRpcResponse<string>> RevokeAsync(IEnumerable<string> addresses,
            BlockchainPermissions permissions, decimal nativeAmount = 0M, string comment = null,
            string commentTo = null, int startBlock = 0, int endBlock = 0)
        {
            var stringifiedAddresses = StringifyValues(addresses);
            var permissionsAsString = FormatPermissions(permissions);
            return ExecuteAsync<string>("revoke", 0, stringifiedAddresses, permissionsAsString);
        }

        public Task<JsonRpcResponse<string>> GrantFromAsync(string fromAddress, IEnumerable<string> toAddresses,
            BlockchainPermissions permissions, decimal nativeAmount = 0M,
            string comment = null, string commentTo = null, int startBlock = 0, int endBlock = 0)
        {
            var stringifiedAddresses = StringifyValues(toAddresses);
            var permissionsAsString = FormatPermissions(permissions);
            return ExecuteAsync<string>("grantfrom", 0, fromAddress, stringifiedAddresses, permissionsAsString);
        }

        public Task<JsonRpcResponse<string>> RevokeFromAsync(string fromAddress, IEnumerable<string> toAddresses,
            BlockchainPermissions permissions, decimal nativeAmount = 0M,
            string comment = null, string commentTo = null, int startBlock = 0, int endBlock = 0)
        {
            var stringifiedAddresses = StringifyValues(toAddresses);
            var permissionsAsString = FormatPermissions(permissions);
            return ExecuteAsync<string>("revokefrom", 0, fromAddress, stringifiedAddresses, permissionsAsString);
        }

        private string FormatPermissions(BlockchainPermissions permissions)
        {
            var builder = new StringBuilder();
            if ((int) (permissions & BlockchainPermissions.Connect) != 0)
                builder.Append("connect");
            if ((int) (permissions & BlockchainPermissions.Send) != 0)
            {
                if (builder.Length > 0)
                    builder.Append(",");
                builder.Append("send");
            }
            if ((int) (permissions & BlockchainPermissions.Receive) != 0)
            {
                if (builder.Length > 0)
                    builder.Append(",");
                builder.Append("receive");
            }
            if ((int) (permissions & BlockchainPermissions.Issue) != 0)
            {
                if (builder.Length > 0)
                    builder.Append(",");
                builder.Append("issue");
            }
            if ((int) (permissions & BlockchainPermissions.Mine) != 0)
            {
                if (builder.Length > 0)
                    builder.Append(",");
                builder.Append("mine");
            }
            if ((int) (permissions & BlockchainPermissions.Admin) != 0)
            {
                if (builder.Length > 0)
                    builder.Append(",");
                builder.Append("admin");
            }

            return builder.ToString();
        }

        public Task<JsonRpcResponse<string>> GetRawTransactionAsync(string txId)
        {
            return ExecuteAsync<string>("getrawtransaction", 0, txId, 0);
        }

        public Task<JsonRpcResponse<VerboseTransactionResponse>> DecodeRawTransactionAsync(string data)
        {
            return ExecuteAsync<VerboseTransactionResponse>("decoderawtransaction", 0, data);
        }

        public Task<JsonRpcResponse<VerboseTransactionResponse>> GetRawTransactionVerboseAsync(string txId)
        {
            return ExecuteAsync<VerboseTransactionResponse>("getrawtransaction", 0, txId, 1);
        }

        private string StringifyValues(IEnumerable<string> values)
        {
            var builder = new StringBuilder();
            foreach (var address in values)
            {
                if (builder.Length > 0)
                    builder.Append(",");
                builder.Append(address);
            }
            return builder.ToString();
        }

        public Task<JsonRpcResponse<string>> GetNewAddressAsync()
        {
            return ExecuteAsync<string>("getnewaddress", 0);
        }

        public Task<JsonRpcResponse<Dictionary<string, object>>> GetBlockchainParamsAsync()
        {
            return ExecuteAsync<Dictionary<string, object>>("getblockchainparams", 0);
        }

        public Task<JsonRpcResponse<Dictionary<string, object>>> GetBlockchainParamsAsync(bool displayNames)
        {
            return ExecuteAsync<Dictionary<string, object>>("getblockchainparams", 0, displayNames);
        }

        public Task<JsonRpcResponse<int>> GetConnectionCountAsync()
        {
            return ExecuteAsync<int>("getconnectioncount", 0);
        }

        public Task<JsonRpcResponse<NetTotalsResponse>> GetNetTotalsAsync()
        {
            return ExecuteAsync<NetTotalsResponse>("getnettotals", 0);
        }

        public Task<JsonRpcResponse<NetworkInfoResponse>> GetNetworkInfoAsync()
        {
            return ExecuteAsync<NetworkInfoResponse>("getnetworkinfo", 0);
        }

        public Task<JsonRpcResponse<decimal>> GetUnconfirmedBalanceAsync()
        {
            return ExecuteAsync<decimal>("getunconfirmedbalance", 0);
        }

        public Task<JsonRpcResponse<WalletInfoResponse>> GetWalletInfoAsync()
        {
            return ExecuteAsync<WalletInfoResponse>("getwalletinfo", 0);
        }

        public Task<JsonRpcResponse<List<TransactionDetailsResponse>>> ListAddressTransactionsAsync(string address, int count = 10,
            int skip = 0)
        {
            return ExecuteAsync<List<TransactionDetailsResponse>>("listaddresstransactions", 0, address, count, skip);
        }

        public Task<JsonRpcResponse<List<TransactionDetailsResponse>>> ListWalletTransactions(int count = 10, int skip = 0)
        {
            return ExecuteAsync<List<TransactionDetailsResponse>>("listwallettransactions", 0, count, skip);
        }

        public Task<JsonRpcResponse<decimal>> EstimateFeeAsync(int numBlocks)
        {
            return ExecuteAsync<decimal>("estimatefee", 0, numBlocks);
        }

        public Task<JsonRpcResponse<decimal>> EstimatePriorityAsync(int numBlocks)
        {
            return ExecuteAsync<decimal>("estimatepriority", 0, numBlocks);
        }

        public Task<JsonRpcResponse<AddressResponse>> ValidateAddressAsync(string address)
        {
            return ExecuteAsync<AddressResponse>("validateaddress", 0, address);
        }

        [Obsolete]
        public Task<JsonRpcResponse<List<TransactionResponse>>> ListTransactionsAsync(string account = null,
            int count = 10, int skip = 0, bool watchOnly = false)
        {
            return ExecuteAsync<List<TransactionResponse>>("listtransactions", 0, account ?? string.Empty, count, skip,
                watchOnly);
        }

        public Task<JsonRpcResponse<string>> SendFromAsync(string fromAccount, string toAddress, decimal amount,
            int confirmations = 1, string comment = null, string commentTo = null)
        {
            return ExecuteAsync<string>("sendfrom", 0, fromAccount ?? string.Empty, toAddress, amount, confirmations,
                comment ?? string.Empty, commentTo ?? string.Empty);
        }

        public Task<JsonRpcResponse<TxOutResponse>> GetTxOutAsync(string txId, int vout = 0, bool unconfirmed = false)
        {
            return ExecuteAsync<TxOutResponse>("gettxout", 0, txId, vout, unconfirmed);
        }

        public Task<JsonRpcResponse<TxOutSetInfoResponse>> GetTxOutSetInfoAsync()
        {
            return ExecuteAsync<TxOutSetInfoResponse>("gettxoutsetinfo", 0);
        }

        public Task<JsonRpcResponse<decimal>> GetBalanceAsync(string account = null, int confirmations = 1,
            bool watchOnly = false)
        {
            return ExecuteAsync<decimal>("getbalance", 0, account ?? "*", confirmations, watchOnly);
        }

        public Task<JsonRpcResponse<bool>> VerifyChainAsync(CheckBlockType type = CheckBlockType.TestEachBlockUndo,
            int numBlocks = 0)
        {
            return ExecuteAsync<bool>("verifychain", 0, (int) type, numBlocks);
        }

        public Task<JsonRpcResponse<string>> AppendRawDataAsync(string txId, object data)
        {
            return ExecuteAsync<string>("appendrawdata", 0, txId, data);
        }

        public Task<JsonRpcResponse<string>> CreateRawTransactionAync(
            IEnumerable<CreateRawTransactionTxIn> txIds = null, IEnumerable<CreateRawTransactionAmount> assets = null)
        {
            dynamic flexible = new ExpandoObject();
            var dictionary = (IDictionary<string, object>) flexible;
            if (assets != null)
                foreach (var asset in assets)
                    dictionary.Add(asset.Address, asset.StringifyAmount());
            return ExecuteAsync<string>("createrawtransaction", 0, txIds ?? new CreateRawTransactionTxIn[0], dictionary);
        }

        public Task<JsonRpcResponse<string>> SendRawTransactionAsync(string hex)
        {
            return ExecuteAsync<string>("sendrawtransaction", 0, hex);
        }

        public Task<JsonRpcResponse<SignRawTransactionResponse>> SignRawTransactionAsync(string hex)
        {
            return ExecuteAsync<SignRawTransactionResponse>("signrawtransaction", 0, hex);
        }

        public Task<JsonRpcResponse<bool>> PrioritiseTransactionAsync(string txId, decimal priority, int feeSatoshis)
        {
            return ExecuteAsync<bool>("prioritisetransaction", 0, txId, priority, feeSatoshis);
        }

        public Task<JsonRpcResponse<long>> GetNetworkHashPsAsync(int blocks = 120, int height = -1)
        {
            return ExecuteAsync<long>("getnetworkhashps", 0, blocks, height);
        }

        public Task<JsonRpcResponse<bool>> SetTxFeeAsync(decimal fee)
        {
            return ExecuteAsync<bool>("settxfee", 0, fee);
        }

        public Task<JsonRpcResponse<List<AssetBalanceResponse>>> GetTotalBalancesAsync(int confirmations = 1,
            bool watchOnly = false, bool locked = false)
        {
            return ExecuteAsync<List<AssetBalanceResponse>>("gettotalbalances", 0, confirmations, watchOnly, locked);
        }

        public Task<JsonRpcResponse<string>> KeypoolRefillAsync(int size = 0)
        {
            return ExecuteAsync<string>("keypoolrefill", 0, size);
        }

        public Task<JsonRpcResponse<object>> GetBlockTemplateAsync()
        {
            return ExecuteAsync<object>("getblocktemplate", 0);
        }

        [Obsolete]
        public Task<JsonRpcResponse<Dictionary<string, decimal>>> ListAccountsAsync()
        {
            return ExecuteAsync<Dictionary<string, decimal>>("listaccounts", 0);
        }

        public Task<JsonRpcResponse<List<List<List<object>>>>> ListAddressGroupingsAsync()
        {
            return ExecuteAsync<List<List<List<object>>>>("listaddressgroupings", 0);
        }

        [Obsolete]
        public Task<JsonRpcResponse<decimal>> GetReceivedByAccountAsync(string account = null, int confirmations = 1)
        {
            return ExecuteAsync<decimal>("getreceivedbyaccount", 0, account ?? string.Empty, confirmations);
        }

        [Obsolete]
        public Task<JsonRpcResponse<List<ReceivedResponse>>> ListReceivedByAddressAsync(int confirmations = 1,
            bool empty = false, bool watchOnly = false)
        {
            return ExecuteAsync<List<ReceivedResponse>>("listreceivedbyaddress", 0, confirmations);
        }

        [Obsolete]
        public Task<JsonRpcResponse<List<ReceivedResponse>>> ListReceivedByAccountAsync(int confirmations = 1,
            bool empty = false, bool watchOnly = false)
        {
            return ExecuteAsync<List<ReceivedResponse>>("listreceivedbyaccount", 0, confirmations);
        }

        [Obsolete]
        public Task<JsonRpcResponse<decimal>> GetReceivedByAddressAsync(string address, int confirmations = 1)
        {
            return ExecuteAsync<decimal>("getreceivedbyaddress", 0, address, confirmations);
        }

        public Task<JsonRpcResponse<GetTransactionResponse>> GetTransactionAsync(string txId, bool watchOnly = false)
        {
            return ExecuteAsync<GetTransactionResponse>("gettransaction", 0, txId, watchOnly);
        }

        public Task<JsonRpcResponse<string>> GetRawChangeAddressAsync()
        {
            return ExecuteAsync<string>("getrawchangeaddress", 0);
        }

        public Task<JsonRpcResponse<string>> ImportAddressAsync(string address, string account = null,
            bool rescan = true)
        {
            return ExecuteAsync<string>("importaddress", 0, address, account ?? string.Empty, rescan);
        }

        public Task<JsonRpcResponse<string>> ImportPrivKey(string key, string account = null, bool rescan = true)
        {
            return ExecuteAsync<string>("importprivkey", 0, key, account ?? string.Empty, rescan);
        }

        [Obsolete]
        public Task<JsonRpcResponse<string>> GetAccountAsync(string address)
        {
            return ExecuteAsync<string>("getaccount", 0, address);
        }

        [Obsolete]
        public Task<JsonRpcResponse<string>> SetAccountAsync(string address, string account)
        {
            return ExecuteAsync<string>("setaccount", 0, address, account);
        }

        [Obsolete]
        public Task<JsonRpcResponse<string>> GetAccountAddressAsync(string account)
        {
            return ExecuteAsync<string>("getaccountaddress", 0, account ?? string.Empty);
        }

        public Task<JsonRpcResponse<List<AssetBalanceResponse>>> GetAssetBalancesAsync(string account = null,
            int confirmations = 1, bool watchOnly = false, bool includeLocked = false)
        {
            return ExecuteAsync<List<AssetBalanceResponse>>("getassetbalances", 0, account ?? string.Empty,
                confirmations, watchOnly, includeLocked);
        }

        public Task<JsonRpcResponse<List<AssetBalanceResponse>>> GetAddressBalancesAsync(string address,
            int confirmations = 1, bool includeLocked = false)
        {
            return ExecuteAsync<List<AssetBalanceResponse>>("getaddressbalances", 0, address, confirmations,
                includeLocked);
        }

        [Obsolete]
        public Task<JsonRpcResponse<List<string>>> GetAddressesByAccountAsync(string account)
        {
            return ExecuteAsync<List<string>>("getaddressesbyaccount", 0, account ?? string.Empty);
        }

        public Task<JsonRpcResponse<ListSinceLastBlockResponse>> ListSinceBlockAsync(string hash, int confirmations = 1,
            bool watchOnly = false)
        {
            return ExecuteAsync<ListSinceLastBlockResponse>("listsinceblock", 0, hash, confirmations, watchOnly);
        }

        public Task<JsonRpcResponse<List<UnspentResponse>>> ListUnspentAsync(int minConf = 1, int maxConf = 999999,
            IEnumerable<string> addresses = null)
        {
            return ExecuteAsync<List<UnspentResponse>>("listunspent", 0, minConf, maxConf);
        }

        public Task<JsonRpcResponse<List<string>>> ListLockUnspentAsync()
        {
            return ExecuteAsync<List<string>>("listlockunspent", 0);
        }

        public Task<JsonRpcResponse<List<string>>> GetAddressesAsync()
        {
            return ExecuteAsync<List<string>>("getaddresses", 0);
        }

        public Task<JsonRpcResponse<List<AddressResponse>>> GetAddressesVerboseAsync()
        {
            return ExecuteAsync<List<AddressResponse>>("getaddresses", 0, true);
        }

        public Task<JsonRpcResponse<string>> PingAsync()
        {
            return ExecuteAsync<string>("ping", 0);
        }

        public Task<JsonRpcResponse<string>> BackupWalletAsync(string path)
        {
            return ExecuteAsync<string>("backupwallet", 0, path);
        }

        public Task<JsonRpcResponse<string>> DumpWalletAsync(string path)
        {
            return ExecuteAsync<string>("dumpwallet", 0, path);
        }

        public Task<JsonRpcResponse<string>> ImportWallet(string path)
        {
            return ExecuteAsync<string>("importwallet", 0, path);
        }

        public Task<JsonRpcResponse<string>> EncryptWalletAsync(string passphrase)
        {
            return ExecuteAsync<string>("encryptwallet", 0, passphrase);
        }

        public Task<JsonRpcResponse<string>> DumpPrivKeyAsync(string address)
        {
            return ExecuteAsync<string>("dumpprivkey", 0, address);
        }

        public Task<JsonRpcResponse<string>> AddNodeAsync(string address, AddNodeCommand command)
        {
            return ExecuteAsync<string>("addnode", 0, address, command.ToString().ToLower());
        }

        public Task<JsonRpcResponse<List<string>>> GetAddedNodeInfoAsync()
        {
            return ExecuteAsync<List<string>>("getaddednodeinfo", 0, false);
        }

        public Task<JsonRpcResponse<List<string>>> GetAddedNodeInfoAsync(string node)
        {
            return ExecuteAsync<List<string>>("getaddednodeinfo", 0, false, node);
        }

        public Task<JsonRpcResponse<List<string>>> GetAddedNodeInfoDetailsAsync()
        {
            return ExecuteAsync<List<string>>("getaddednodeinfo", 0, true);
        }

        public Task<JsonRpcResponse<List<string>>> GetAddedNodeInfoDetailsAsync(string node)
        {
            return ExecuteAsync<List<string>>("getaddednodeinfo", 0, true, node);
        }

        public Task<JsonRpcResponse<MultiSigResponse>> CreateMultiSigAsync(int numRequired,
            IEnumerable<string> addresses)
        {
            return ExecuteAsync<MultiSigResponse>("createmultisig", 0, numRequired, addresses);
        }

        public Task<JsonRpcResponse<string>> SubmitBlockAsync(byte[] bs, object args = null)
        {
            if (args != null)
                return ExecuteAsync<string>("submitblock", 0, bs, args);
            return ExecuteAsync<string>("submitblock", 0, bs);
        }

        public Task<JsonRpcResponse<ScriptResponse>> DecodeScriptAsync(string decodeScript)
        {
            return ExecuteAsync<ScriptResponse>("decodescript", 0, decodeScript);
        }

        [Obsolete]
        public Task<JsonRpcResponse<string>> AddMultiSigAddressAsync(int numRequired, IEnumerable<string> addresses,
            string account = null)
        {
            return ExecuteAsync<string>("addmultisigaddress", 0, numRequired, addresses, account ?? string.Empty);
        }

        public Task<JsonRpcResponse<string>> HelpAsync()
        {
            return ExecuteAsync<string>("help", 0);
        }

        public Task<JsonRpcResponse<string>> HelpAsync(string command)
        {
            return ExecuteAsync<string>("help", 0, command);
        }

        public Task<JsonRpcResponse<object>> StopAsync()
        {
            return ExecuteAsync<object>("stop", 0);
        }

        public static string FormatHex(byte[] bs)
        {
            var builder = new StringBuilder();
            foreach (var b in bs)
                builder.Append(b.ToString("x2"));
            return builder.ToString();
        }

        private async Task<JsonRpcResponse<T>> ExecuteAsync<T>(string method, int id, params object[] args)
        {
            var ps = new JsonRpcRequest
            {
                Method = method,
                Params = args,
                ChainName = ChainName,
                ChainKey = ChainKey,
                Id = id
            };

            // defer...
            OnExecuting(new EventArgs<JsonRpcRequest>(ps));

            var jsonOut = JsonConvert.SerializeObject(ps.Values);
            var url = ServiceUrl;
            try
            {
                var request = WebRequest.CreateHttp(url);
                request.Credentials = GetCredentials();
                request.Method = "POST";

                var bs = Encoding.UTF8.GetBytes(jsonOut);
                using (var stream = await request.GetRequestStreamAsync())
                {
                    stream.Write(bs, 0, bs.Length);
                }

                // get the response...
                var response = await request.GetResponseAsync();
                string jsonIn = null;
                using (var stream = ((HttpWebResponse) response).GetResponseStream())
                {
                    jsonIn = await new StreamReader(stream).ReadToEndAsync();
                }

                // return...
                JsonRpcResponse<T> theResult = null;
                try
                {
                    theResult = JsonConvert.DeserializeObject<JsonRpcResponse<T>>(jsonIn);
                }
                catch (Exception jsonEx)
                {
                    throw new InvalidOperationException("Failed to deserialize JSON.\r\nJSON: " + jsonIn, jsonEx);
                }
                theResult.RawJson = jsonIn;
                return theResult;
            }
            catch (Exception ex)
            {
                var walk = ex;
                string errorData = null;
                while (walk != null)
                {
                    if (walk is WebException)
                    {
                        var webEx = (WebException) walk;
                        if (webEx.Response != null)
                            using (var stream = webEx.Response.GetResponseStream())
                            {
                                errorData = new StreamReader(stream).ReadToEnd();
                            }

                        break;
                    }

                    walk = walk.InnerException;
                }

                throw new InvalidOperationException(
                    $"Failed to issue JSON-RPC request.\r\nData: {errorData}\r\nURL: {url}\r\nJSON: {jsonOut}", ex);
            }
        }

        protected virtual void OnExecuting(EventArgs<JsonRpcRequest> e)
        {
            Executing?.Invoke(this, e);
        }

        private ICredentials GetCredentials()
        {
            return HasCredentials ? new NetworkCredential(Username, Password) : null;
        }

        #region Streams

        public Task<JsonRpcResponse<string>> CreateStreamAsync(string name, bool open)
        {
            return ExecuteAsync<string>("create", 0, "stream", name, open);
        }

        public Task<JsonRpcResponse<string>> CreateStreamFromAsync(string fromAddress, string name, bool open)
        {
            return ExecuteAsync<string>("create", 0, fromAddress, "stream", name, open);
        }

        public Task<JsonRpcResponse<List<ListStreamResponse>>> ListStreams(string streams = "*")
        {
            return ExecuteAsync<List<ListStreamResponse>>("liststreams", 0, streams);
        }

        public Task<JsonRpcResponse<string>> PublishAsync(string stream, string key, byte[] data)
        {
            return ExecuteAsync<string>("publish", 0, stream, key, FormatHex(data));
        }

        public Task<JsonRpcResponse<string>> PublishFromAsync(string fromAddress, string stream, string key, byte[] data)
        {
            return ExecuteAsync<string>("publishfrom", 0, fromAddress, stream, key, FormatHex(data));
        }

        public Task<JsonRpcResponse<List<ListStreamKeysResponse>>> ListStreamKeys(string stream, string keys = "*")
        {
            return ExecuteAsync<List<ListStreamKeysResponse>>("liststreamkeys", 0, stream, keys);
        }

        public Task<JsonRpcResponse<List<ListStreamKeyItemsResponse>>> ListStreamKeyItems(string stream, string key)
        {
            return ExecuteAsync<List<ListStreamKeyItemsResponse>>("liststreamkeyitems", 0, stream, key);
        }

        #endregion
    }
}