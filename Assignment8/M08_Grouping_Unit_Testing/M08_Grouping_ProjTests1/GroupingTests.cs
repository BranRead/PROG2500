using Microsoft.VisualStudio.TestTools.UnitTesting;
using M01_First_WPF_Proj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace M01_First_WPF_Proj.Tests
{
    [TestClass()]
    public class GroupingTests
    {
        [TestMethod()]
        public void GetGroupTest1()
        {
            int distanceThreshold = 100;
            int num_of_points = 2;
            Grouping g = null;
            g = new Grouping(distanceThreshold, num_of_points);
            g.MasterList[0] = new Point(0, 0);
            g.MasterList[1] = new Point(100, 0);

            List<List<Point>> groupings = g.applyThreseholdsMakeGroups();

            int Actual_Group_Count = groupings.Count;
            int Expected_Group_Count = 2;
            Assert.AreEqual(Actual_Group_Count, Expected_Group_Count);
        }

        [TestMethod()]
        public void GetGroupTest2()
        {
            int distanceThreshold = 100;
            int num_of_points = 2;
            Grouping g = null;
            g = new Grouping(distanceThreshold, num_of_points);
            g.MasterList[0] = new Point(0, 0);
            g.MasterList[1] = new Point(0, 100);

            List<List<Point>> groupings = g.applyThreseholdsMakeGroups();

            int Actual_Group_Count = groupings.Count;
            int Expected_Group_Count = 2;
            Assert.AreEqual(Actual_Group_Count, Expected_Group_Count);
        }

        [TestMethod()]
        public void GetGroupTest3()
        {
            int distanceThreshold = 100;
            int num_of_points = 2;
            Grouping g = null;
            g = new Grouping(distanceThreshold, num_of_points);
            g.MasterList[0] = new Point(0, 0);
            g.MasterList[1] = new Point(86, 50);

            List<List<Point>> groupings = g.applyThreseholdsMakeGroups();

            int Actual_Group_Count = groupings.Count;
            int Expected_Group_Count = 1;
            Assert.AreEqual(Actual_Group_Count, Expected_Group_Count);
        }

        [TestMethod()]
        public void GetGroupTest4()
        {
            int distanceThreshold = 100;
            int num_of_points = 2;
            Grouping g = null;
            g = new Grouping(distanceThreshold, num_of_points);
            g.MasterList[0] = new Point(87, 50);
            g.MasterList[1] = new Point(0, 0);

            List<List<Point>> groupings = g.applyThreseholdsMakeGroups();

            int Actual_Group_Count = groupings.Count;
            int Expected_Group_Count = 2;
            Assert.AreEqual(Actual_Group_Count, Expected_Group_Count);
        }

        [TestMethod()]
        public void GetGroupTest5()
        {
            int distanceThreshold = 100;
            int num_of_points = 2;
            Grouping g = null;
            g = new Grouping(distanceThreshold, num_of_points);
            g.MasterList[0] = new Point(50, 35);
            g.MasterList[1] = new Point(136, 85);

            List<List<Point>> groupings = g.applyThreseholdsMakeGroups();

            int Actual_Group_Count = groupings.Count;
            int Expected_Group_Count = 1;
            Assert.AreEqual(Actual_Group_Count, Expected_Group_Count);
        }
    }
}