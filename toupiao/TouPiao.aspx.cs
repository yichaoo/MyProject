using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace weixin_testcode
{
    public partial class TouPiao : System.Web.UI.Page
    {
        int totalCreated = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            //this.txtResponseContent.Enabled = false;
            //this.txtRandomRequest.Enabled = false;
            //this.txtRefererUrl.Enabled = false;
            //this.txtUrl.Enabled = false;
            if (IsPostBack == false)
            {
                this.txtUrl.Text = "https://es.hbsrcfwj.cn/toupiaos/fabulous?refresh";
            }
          
           
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
          
            int totalUserNum = int.Parse(ddlNum.SelectedItem.Value);
            PostRequest(totalUserNum);
        }

        private string GetRespose(string requestBodyData)
        {
            string Response = "";
            if (requestBodyData != "")
            {
                if (ddlMethod.SelectedItem.Value == "GET")
                {
                    Response = HttpHelper.Get(this.txtUrl.Text.Trim(), "UTF-8", ddlContentType.SelectedValue);//application/xml,application/json
                }
                else
                {
                    Response = HttpHelper.Post(this.txtUrl.Text.Trim(),requestBodyData, "UTF-8", txtRefererUrl.Text.Trim());
                }
                if (Response.IndexOf("created") > -1)
                {
                    this.txtResponseContent.Text += Response + "\r\n";
                    totalCreated += 1;
                    this.TextBox1.Text += "created:ture 本次累计投票数：" +totalCreated+ "\r\n";
                }

            }
            return Response;
        }

        private void PostRequest(int totalNum)
        {

            for (int t = 1; t <= totalNum; t++)
            {
            
                string postID = "AWdj8Hz1hgg1MDBgtZUG";//前包ID


                //int _24int = (new Random()).Next(1, 23);
                int gender = (new Random()).Next(0, 1);

                string strNickName = GetRandomNickName();

                //strNickName = "嘟嘟";
                string str92 = GetRandomString(92, false);
                string str24 = GetRandomString(24, true);
                string openID = "oc8" + "_" + str24;
                //openID = "oc8_H5TRq6FHUmidlh7XX9rbChoI";
                string ip16 = "219." + (new Random()).Next(138, 140) + "." + (new Random()).Next(0, 248) + "." + (new Random()).Next(66, 255);

                //     DateTime createDate = DateTime.Now.AddMinutes(m);


                string requestText = "";

                for (int i = 1; i <= 3; i++)
                {
                    int _60Seconds = (new Random()).Next(1, 59);
                    int _60Minutes = (new Random()).Next(1, 59);
                    string createDate = DateTime.Now.AddSeconds(_60Seconds).ToString("yyyy-MM-dd HH:mm:ss"); //时间随机
                    requestText += "{\"postId\":\"" + postID + "\",\"createDate\":\"" + createDate + "\",";
                    requestText += "\"userInfo\":{\"nickName\":\"" + strNickName + "\",\"gender\":" + gender + ",\"language\":\"zh_CN\",\"city\":\"\",\"province\":\"\",\"country\":\"\",";
                    requestText += "\"avatarUrl\":\"https://wx.qlogo.cn/mmopen/vi_32/" + str92 + "\"},";
                    requestText += "\"openId\":\"" + openID + "\",\"ip\":\"" + ip16 + "\"}";
                    GetRespose(requestText);
                    this.txtRandomRequest.Text += requestText+"\r\n";
                    requestText = "";
                   
                }
            }
            
        }

        #region 5.0 生成随机字符串 + static string GetRandomString(int length, bool useNum, bool useLow, bool useUpp, bool useSpe, string custom)
        ///<summary>
        ///生成随机字符串 
        ///</summary>
        ///<param name="length">目标字符串的长度</param>
        ///<param name="useNum">是否包含数字，1=包含，默认为包含</param>
        ///<param name="useLow">是否包含小写字母，1=包含，默认为包含</param>
        ///<param name="useUpp">是否包含大写字母，1=包含，默认为包含</param>
        ///<param name="useSpe">是否包含特殊字符，1=包含，默认为不包含</param>
        ///<param name="custom">要包含的自定义字符，直接输入要包含的字符列表</param>
        ///<returns>指定长度的随机字符串</returns>
        public static string GetRandomString(int length, bool useNum, bool useLow, bool useUpp, bool useSpe, string custom)
        {
            byte[] b = new byte[4];
            new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(b);
            Random r = new Random(BitConverter.ToInt32(b, 0));
            string s = null, str = custom;
            if (useNum == true) { str += "0123456789"; }
            if (useLow == true) { str += "abcdefghijklmnopqrstuvwxyz"; }
            if (useUpp == true) { str += "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; }
            if (useSpe == true) { str += "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~"; }
            for (int i = 0; i < length; i++)
            {
                s += str.Substring(r.Next(0, str.Length - 1), 1);
            }
            return s;
        }

        public static string GetRandomString(int length, bool useNum)
        {
            return GetRandomString(length, useNum, true, true, false, "");
        }
        #endregion

        
        // 获取随机昵称
        public string GetRandomNickName()
        {
            string[] nickArray = null;
            string arrayName = "揽月敬风尘、十里归途、凉.忆、一个人的旅行、静若安然、╰鸢尾花ぴ,情殇ぇ、为啥拉钩还上吊、单身成瘾、言辞、抗氓卑鄙、两清、不配拥有爱、";
            arrayName += "快意人生、吊儿啷当、步子迈大了难免扯着蛋、性感的小禽兽、吃兔子的胡萝卜、再贱就再见、风吹裤衩屁屁凉、含笑半步颠、纠结的小丸子、屎了都要爱、小嘴巴嘟嘟、西瓜菇凉、疯人疯言疯语、骚得够洋气、贱得有出息、睡姿决定发型、犯二的骚年、被窝比美女的诱惑更大、叽叽喳喳、";
            arrayName += "路过的风、踩着棺材跳鬼步、柠檬不该羡慕西瓜甜、我与世界只差一个你、不美不萌照样拽、孤独成瘾、我病态见不得别人恩爱、欧巴欧巴撒浪嘿、巷尾樱花、趁爱不深、你怕黑我就送你整片星空、思念说给风听、三分清醒七分醉、鱼的第八秒是重生、借风吻你、执念太深、离人何必挽、素颜倾心不倾城、";
            arrayName += "装在口袋的幸福、含泪而笑、执笔追忆、想念念给谁听、最阳光的笑脸、鸳鸯戏水、于是就算了吧、我也要找到你、绽放你的美、浅唱那悲伤、这样滥情何苦、流星残留的温柔、心疼你的心疼、流着泪说分手、不确定的唯一、下一天画蓝、雨天也晴朗、带刺的蔷薇、我的心好冷、守住那心坟、友情算什么、完美并不美、";
            arrayName += "住那心坟、友情算什么、完美并不美、破碎、蜕变、仰望、柒月、浮夸、初夏、旧颜、浅念、止步、傀儡、汐颜、旧城、昔年、孽缘、甜心、淡然、夏夜、花颜、释然、堇年、梦醒、浅忆、等你、惜染、冷瞳、落幕、泡泡、堇年、微凉、癫子、祭逝、冷瞳、温瞳、婉儿、初夏、陌颜、残舞、旧颜、凌乱、恋蝶、瞳孔、雨天、夏沫、";
            arrayName += "Hickey吻痕、hurriedly匆匆、Treasure珍重、rostiute入戏、Taurus挽歌、Bitter泪海、Iruri过客、Outsider外人、overdoes上瘾、Trister旧情人、Brithday失去、shallow庸人、buildings阡陌、runaway逃跑、Appoint约定、Agoni暮念、Childheart虐心、Archer久遇、Survivor幸存者、Destiny宿命";       
            nickArray = arrayName.Split('、');
            int len = nickArray.Length;
            System.Random random = new System.Random();
            int index = random.Next(len);
            string str = nickArray[index];
            return str;
        }

        protected void btnRandom_Click(object sender, EventArgs e)
        {
            //CreateRequest();
        }

        protected void txtRefererUrl_TextChanged(object sender, EventArgs e)
        {

        }

    }
}