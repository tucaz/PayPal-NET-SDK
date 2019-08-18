using System;
using PayPal.Util;
using Xunit;


namespace PayPal.Testing
{
    
    public class ArgumentValidatorTest
    {
        [Fact, Trait("Category", "Unit")]
        public void EmptyStringMustThrow()
        {
            try
            {
                ArgumentValidator.Validate("", "EmptyString");
            }
            catch (Exception ex)
            {
                Assert.True(ex is ArgumentNullException);
            }
        }

        [Fact, Trait("Category", "Unit")]
        public void NullStringMustThrow()
        {
            try
            {
                string str = null;
                ArgumentValidator.Validate(str, "NullString");
            }
            catch (Exception ex)
            {
                Assert.True(ex is ArgumentNullException);
            }
        }

        [Fact, Trait("Category", "Unit")]
        public void BooleanMustDoesntThrow()
        {
            try
            {
                ArgumentValidator.Validate(false, "NullString");
            }
            catch (Exception ex)
            {
                Assert.False(ex is ArgumentNullException);
            }
        }

        [Fact, Trait("Category", "Unit")]
        public void IntegerMustDoesntThrow()
        {
            try
            {
                ArgumentValidator.Validate(15, "NullString");
            }
            catch (Exception ex)
            {
                Assert.False(ex is ArgumentNullException);
            }
        }

        [Fact, Trait("Category", "Unit")]
        public void ObjectMustDoesntThrow()
        {
            try
            {
                ArgumentValidator.Validate(new Object(), "NullString");
            }
            catch (Exception ex)
            {
                Assert.False(ex is ArgumentNullException);
            }
        }

        [Fact, Trait("Category", "Unit")]
        public void NullObjectMustThrow()
        {
            try
            {
                ArgumentValidator.Validate(null, "NullString");
            }
            catch (Exception ex)
            {
                Assert.True(ex is ArgumentNullException);
            }
        }

        [Fact, Trait("Category", "Unit")]
        public void NullableBooleanMustThrow()
        {
            try
            {
                bool? nullableBool = null;
                ArgumentValidator.Validate(nullableBool, "NullString");
            }
            catch (Exception ex)
            {
                Assert.True(ex is ArgumentNullException);
            }
        }
    }
}
