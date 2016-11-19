using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    public enum CurrencyType
    {
        Eur,
        Dollar,
        Ruble
    }

    public class Cash
    {
        public Cash(CurrencyType currency, int value)
        {
            Currency = currency;
            Value = value;
        }

        public CurrencyType Currency { get; set; }
        public int Value { get; set; }
    }

    public class Bancomat
    {
        private readonly BanknoteHandler _handler;

        public Bancomat()
        {
            _handler = new TenRubleHandler(null);
            _handler = new TenDollarHandler(_handler);
            _handler = new FiftyDollarHandler(_handler);
            _handler = new HundredDollarHandler(_handler);
        }

        public bool Validate(string banknote)
        {
            return _handler.Validate(banknote);
        }

        public string Cashed(Cash cash) => _handler.Cashed(cash);
    }

    public abstract class BanknoteHandler
    {
        private readonly BanknoteHandler _nextHandler;

        protected BanknoteHandler(BanknoteHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public virtual bool Validate(string banknote)
        {
            return _nextHandler != null && _nextHandler.Validate(banknote);
        }

        public virtual string Cashed(Cash cash)
        {
            if (cash.Value == 0) return "";
            return (_nextHandler != null) ? _nextHandler.Cashed(cash) : $"{cash.Value} не валидная сумма =(";
        }
    }

    public class TenRubleHandler : BanknoteHandler
    {
        public override bool Validate(string banknote)
        {
            if (banknote.Equals("10 Рублей"))
            {
                return true;
            }
            return base.Validate(banknote);
        }

        public override string Cashed(Cash cash)
        {
            if (cash.Currency != CurrencyType.Ruble) return base.Cashed(cash);
            var count = cash.Value/10;
            cash.Value -= 10*count;
            return $"10x{count} {base.Cashed(cash)}";
        }

        public TenRubleHandler(BanknoteHandler nextHandler) : base(nextHandler)
        { }
    }

    public abstract class DollarHandlerBase : BanknoteHandler
    {
        public override bool Validate(string banknote)
        {
            if (banknote.Equals($"{Value}$"))
            {
                return true;
            }
            return base.Validate(banknote);
        }

        public override string Cashed(Cash cash)
        {
            if (cash.Currency != CurrencyType.Dollar) return base.Cashed(cash);
            var count = cash.Value / Value;
            cash.Value -= Value * count;
            return $"{Value}x{count} {base.Cashed(cash)}";
        }

        protected abstract int Value { get; }

        protected DollarHandlerBase(BanknoteHandler nextHandler) : base(nextHandler)
        {
        }
    }

    public class HundredDollarHandler : DollarHandlerBase
    {
        protected override int Value => 100;

        public HundredDollarHandler(BanknoteHandler nextHandler) : base(nextHandler)
        { }
    }

    public class FiftyDollarHandler : DollarHandlerBase
    {
        protected override int Value => 50;

        public FiftyDollarHandler(BanknoteHandler nextHandler) : base(nextHandler)
        { }
    }

    public class TenDollarHandler : DollarHandlerBase
    {
        protected override int Value => 10;

        public TenDollarHandler(BanknoteHandler nextHandler) : base(nextHandler)
        { }
    }
}
