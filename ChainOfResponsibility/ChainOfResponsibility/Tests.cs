using NUnit.Framework;
using FluentAssertions;

namespace ChainOfResponsibility
{
    class Bancomat_should
    {
        [Test]
        public void CashedRuble()
        {
            var bancomat = new Bancomat();

            bancomat.Cashed(new Cash(CurrencyType.Ruble, 1000)).Should().BeEquivalentTo("10x100 ");
            bancomat.Cashed(new Cash(CurrencyType.Ruble, 15))
                .Should().BeEquivalentTo("10x1 5 не валидная сумма =(");
        }

        [Test]
        public void CashedDollar()
        {
            var bancomat = new Bancomat();

            bancomat.Cashed(new Cash(CurrencyType.Dollar, 180))
                .Should().BeEquivalentTo("100x1 50x1 10x3 ");
            bancomat.Cashed(new Cash(CurrencyType.Dollar, 1015))
                .Should().BeEquivalentTo("100x10 50x0 10x1 5 не валидная сумма =(");
        }
    }
}
