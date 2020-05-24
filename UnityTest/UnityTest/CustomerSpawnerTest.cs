using System;
using System.Collections.Generic;
using System.Text;

namespace UnityTest
{
    class CustomerSpawnerTest
    {

        //CustomerSpawner is a class which I assume exists in the unity project. Maybe with a different name.
        [UnityTest]
        public IEnumerator _Instantiantes_GameObject_From_PreFab()
        {
            var customerPrefab = Resource.Load("Tests/customer");
            var customerSpawner = new GameObject().AddComponent<CustomerSpawner>();
            customerSpawner.Construct(customerPrefab, 0, 1);

            yield return null;
            var spawnedCustomer = GameObject.FindWithTag("Customer");
            var prefabTheSpawnedCustomer = PrefabUtility.GetPRefabParent(spawnedCustomer);
            Assert.AreEqual(customerPrefab, prefabTheSpawnedCustomer);
        }

        [UnityTest]
        public IEnumerator _Instantiantes_GameObject_At_Random_Position_On_Circle__Boundary()
        {
            var customerPrefab = Resource.Load("Tests/customer");
            var customerSpawner = new GameObject().AddComponent<CustomerSpawner>();
            customerSpawner.Construct(customerPrefab, 0, 1);
            var random = NSubstitude.Substitude.For<System.Random>();
            random.Next(Arg.Any<int>, Arg.Any<int>()).Returns(270);
            customerSpawner.Random = random;

            yield return null;

            var spawnedCustomer = GameObject.FindWithTag("Customer");
            var expectedPosition = new Vector(0, 0, -1);

            Assert.AreEqual(customerPrefab, spawnedCustomer.transform.position);
        }
        [UnityTest]
        public IEnumerator _Instantiantes_Occur_On_An_Interval()
        {
            var customerPrefab = Resource.Load("Tests/customer");
            var customerSpawner = new GameObject().AddComponent<CustomerSpawner>();
            customerSpawner.Construct(customerPrefab, 1, 1);
            yield return new WaitForSeconds(0.75f);
            var spawnedCustomer = GameObject.FindWithTag("Customer");

            Assert.IsNull(spawnedCustomer);
        }


        [TearDown]
        public void AfterEveryTest()
        {
            foreach (var gameObject in GameObject.FindGameObjectsWithTag("Customer"))
            {
                Object.Destroy(gameObject);
            }
            foreach (var gameObject in GameObject.FindObjectsOfType<CustomerSpawner>())
            {
                Object.Destroy(gameObject);
            }
        }
    }
}
