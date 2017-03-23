using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LiqPayTest
{
    struct Params
    {
        public DateTime from;
        public DateTime to;
    }
    class CheckerManager
    {
        DateTime From;
        DateTime To;

        public LiqPay LiqPay;
        public WayForPay WayForPay;
        public Frontmanager Frontmanager;

        public CheckerManager(DateTime from, DateTime to = default(DateTime))
        {
            From = from;
            if(to == default(DateTime))
                To = DateTime.Now;
            else
                To = to;

            LiqPay = new LiqPay();
            WayForPay = new WayForPay();
            Frontmanager = new Frontmanager();

            Params param;
            param.from = From;
            param.to = To;

            Thread liq = new Thread(new ParameterizedThreadStart(Liq));
            liq.Start(param);

            Thread way = new Thread(new ParameterizedThreadStart(Way));
            way.Start(param);

            Thread fro = new Thread(new ParameterizedThreadStart(Fro));
            fro.Start(param);
        }
        public StringBuilder CheckWithLiqPay()
        {
            StringBuilder log = new StringBuilder();
            var res1 = Frontmanager.Orders.Keys.Intersect(LiqPay.Orders.Keys);
 
            foreach (var item in res1)
            {
                if(Frontmanager.Orders[item].Status == Frontmanager.Status.Success.ToString() && LiqPay.Orders[item].Status != "success")
                {
                    log.Append(Frontmanager.Orders[item] + "\n");
                }
            }

            if(log.Length == 0)
            {
                log.Append("Проверка Прошлла Успешно\n");
            }
            log.Append("Total Count: "+res1.Count());
            return log;
        }
        public StringBuilder CheckWithWayForPay()
        {
            StringBuilder log = new StringBuilder();
            var res1 = Frontmanager.Orders.Keys.Intersect(WayForPay.Orders.Keys);
            foreach (var item in res1)
            {
                if (Frontmanager.Orders[item].Status == Frontmanager.Status.Success.ToString() && WayForPay.Orders[item].Status != "Approved")
                {
                    log.Append(Frontmanager.Orders[item] + "\n");
                }
            }

            if (log.Length == 0)
            {
                log.Append("Проверка Прошлла Успешно");
            }
            return log;
        }
        public StringBuilder GetAllOrdersLiqPay()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in LiqPay.Orders)
            {
                sb.Append(item.Value + "\n");
            }
            sb.Append("Total Count: " + LiqPay.Orders.Count);
            return sb;
        }
        public StringBuilder GetAllOrdersWayForPay()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in WayForPay.Orders)
            {
                sb.Append(item.Value + "\n");
            }
            sb.Append("Total Count: " + WayForPay.Orders.Count);
            return sb;
        }
        public StringBuilder GetAllOrdersWayFrontmanager()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in Frontmanager.Orders)
            {
                sb.Append(item.Value + "\n");
            }
            sb.Append("Total Count: " + Frontmanager.Orders.Count);
            return sb;
        }

        void Liq(object param)
        {
            Params par = (Params)param;
            LiqPay.GetOrders(par.from, par.to);
            MessageBox.Show("LiqPay is Finished");
        }
        void Way(object param)
        {
            Params par = (Params)param;
            WayForPay.GetOrders(par.from, par.to);
            MessageBox.Show("WayForPay is Finished");
        }
        void Fro(object param)
        {
            Params par = (Params)param;
            Frontmanager.GetOrders(par.from, par.to);
            MessageBox.Show("Frontmanager is Finished");
        }

        public StringBuilder UnexistingOrdersLiqPay()
        {
            StringBuilder log = new StringBuilder();
            var res1 = LiqPay.Orders.Keys.Except(Frontmanager.Orders.Keys);

            foreach (var item in res1)
            {
                log.Append(item + "\n");
            }
            log.Append("Total Count: " + res1.Count());
            return log;
        }
        public StringBuilder ExistingOrdersLiqPay()
        {
            StringBuilder log = new StringBuilder();
            var res1 = LiqPay.Orders.Keys.Intersect(Frontmanager.Orders.Keys);

            foreach (var item in res1)
            {
                log.Append(item + "\n");
            }
            log.Append("Total Count: " + res1.Count());
            return log;
        }

        public StringBuilder UnexistingOrdersWayForPay()
        {
            StringBuilder log = new StringBuilder();
            var res1 = WayForPay.Orders.Keys.Except(Frontmanager.Orders.Keys);

            foreach (var item in res1)
            {
                log.Append(item + "\n");
            }
            log.Append("Total Count: " + res1.Count());
            return log;
        }
        public StringBuilder ExistingOrdersWayForPay()
        {
            StringBuilder log = new StringBuilder();
            var res1 = WayForPay.Orders.Keys.Intersect(Frontmanager.Orders.Keys);

            foreach (var item in res1)
            {
                log.Append(item + "\n");
            }
            log.Append("Total Count: " + res1.Count());
            return log;
        }
    }
}
