using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using NUnit.Framework;
using System.Threading.Tasks;
using Sandbox.LinkListExercise;

namespace SandboxTests.LinkListExercise
{
    // NameOfMethod_WordsThatExplainTheSetUp_WordsThatExplainTheExpectedResult

    public class FakeObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class FakeConsole : IConsole
    {
        public List<string> ConsoleWrittenLines = new List<string>();

        public void WriteLine(string value)
        {
            ConsoleWrittenLines.Add(value);
        }
    }

    [TestFixture]
    public class MyListTests
    {
        public FakeConsole FakeConsole = new FakeConsole();
        public MyList<FakeObject> BuildMyList() => new MyList<FakeObject>(FakeConsole);

        [SetUp]
        public void SetUp()
        {
            FakeConsole = new FakeConsole();
        }

        [Test]
        public async Task Test_SSN()
        {
            var foo = RunThing.DoThing();
        }

        [Test]
        public async Task Print_TestPrint()
        {
            var myList = BuildMyList();

            myList.Add(new FakeObject
            {
                Id = 1,
                Name = "foo"
            });

            myList.Print();

            Assert.AreEqual(1, FakeConsole.ConsoleWrittenLines.Count);
            Assert.AreEqual("{\"Id\":1,\"Name\":\"foo\"}", FakeConsole.ConsoleWrittenLines[0]);
        }

        [Test]
        public async Task Add_IncreasesLengthOfListBy1()
        {
            var myList = BuildMyList();

            myList.Add(new FakeObject
            {
                Id = 1, 
                Name = "foo"
            });

            Assert.AreEqual(1, myList.Length());
        }

        [Test]
        public async Task Where_FromFrontOfList_ReturnsAListOfTheCorrectLength()
        {
            var myList = AddThreeListItems();

            var myWhereList = myList.Where(x => x.Id != 1);

            Assert.AreEqual(2, myWhereList.Length());
        }

        [Test]
        public async Task Where_FromBackOfList_ReturnsAListOfTheCorrectLength()
        {
            var myList = AddThreeListItems();

            var myWhereList = myList.Where(x => x.Id != 3);

            Assert.AreEqual(2, myWhereList.Length());
        }

        [Test]
        public async Task FirstOrDefault_ReturnsCorrectItem()
        {
            var myList = BuildMyList();

            var fakeObject = new FakeObject
            {
                Id = 1,
                Name = "Foo"
            };

            myList.Add(fakeObject);

            var first = myList.FirstOrDefault(x => x.Id == 1);

            Assert.AreEqual(fakeObject, first);
        }

        [Test]
        public async Task FirstOrDefault_ReturnsOnlyOneItem()
        {
            var myList = BuildMyList();

            var expected = new FakeObject
            {
                Id = 1,
                Name = "Foo",
            };

            myList.Add(expected);

            myList.Add(new FakeObject
            {
                Id = 1,
                Name = "Bar",
            });

            var first = myList.FirstOrDefault(x => x.Id == 1);

            Assert.AreEqual(expected, first);
        }

        [Test]
        public async Task FirstOrDefault_ReturnsDefault()
        {
            var myList = AddFiveListItems();

            var foo = myList.FirstOrDefault(x => x.Id == 100000);

            Assert.AreEqual(default(FakeObject), foo);
        }
        
        [Test]
        public async Task Print_DoesNotReturnEmptyWhenThereAreValues()
        {
            var myList = AddFiveListItems();

            var foo = myList.Stringify_All();

            Assert.AreNotEqual(foo, "");
        }

        [Test]
        public async Task Print_DoesReturnEmptyWhenThereArentValues()
        {
            var myList = BuildMyList();

            var foo = myList.Stringify_All();

            Assert.AreEqual(foo, "");
        }

        [Test]
        public async Task Delete_DeletingFirstOfList_FirstItemIsActuallyGone()
        {
            var myList = BuildMyList();

            var fo1 = new FakeObject
            {
                Id = 1,
                Name = "foo"
            };

            var fo2 = new FakeObject
            {
                Id = 2,
                Name = "bar"
            };

            var fo3 = new FakeObject
            {
                Id = 2,
                Name = "buzz"
            };

            myList.Add(fo1);
            myList.Add(fo2);
            myList.Add(fo3);

            myList.Delete(fo1);

            var foo = myList.Where(x => x == fo1);
            Assert.AreEqual(0, foo.Length());
        }

        [Test]
        public async Task Delete_WorksOnEndOfList()
        {
            var myList = BuildMyList();

            var fo1 = new FakeObject
            {
                Id = 1,
                Name = "foo"
            };

            var fo2 = new FakeObject
            {
                Id = 2,
                Name = "bar"
            };

            var fo3 = new FakeObject
            {
                Id = 2,
                Name = "buzz"
            };

            myList.Add(fo1);
            myList.Add(fo2);
            myList.Add(fo3);

            myList.Delete(fo3);

            Assert.AreEqual(2, myList.Length());
        }

        [Test]
        public async Task Delete_WorksOnMiddleOfList()
        {
            var myList = BuildMyList();

            var fo1 = new FakeObject
            {
                Id = 1,
                Name = "foo"
            };

            var fo2 = new FakeObject
            {
                Id = 2,
                Name = "bar"
            };

            var fo3 = new FakeObject
            {
                Id = 2,
                Name = "buzz"
            };

            myList.Add(fo1);
            myList.Add(fo2);
            myList.Add(fo3);

            myList.Delete(fo2);

            Assert.AreEqual(2, myList.Length());
        }

        public MyList<FakeObject> AddThreeListItems()
        {
            var myList = BuildMyList();

            myList.Add(new FakeObject
            {
                Id = 1,
                Name = "foo"
            });

            myList.Add(new FakeObject
            {
                Id = 2,
                Name = "bar"
            });

            myList.Add(new FakeObject
            {
                Id = 3,
                Name = "buzz"
            });

            return myList;
        }

        public MyList<FakeObject> AddFiveListItems()
        {
            var myList = BuildMyList();

            myList.Add(new FakeObject
            {
                Id = 1,
                Name = "foo"
            });

            myList.Add(new FakeObject
            {
                Id = 2,
                Name = "bar"
            });

            myList.Add(new FakeObject
            {
                Id = 3,
                Name = "buzz"
            });

            myList.Add(new FakeObject
            {
                Id = 4,
                Name = "bar"
            });

            myList.Add(new FakeObject
            {
                Id = 5,
                Name = "buzz"
            });

            return myList;
        }
    }
}
