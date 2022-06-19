using System.Threading.Tasks;
using UnityEngine;

namespace Interfaces
{
    public interface ISkillInfo
    {

    }
    public interface IGameSystem
    {
        public Task Update(ICard card);
    }
    public interface IController
    {
        public void Init(GameObject target);
        public void Destroy();
    }

   public interface ICard
    {
        public GameObject GetGameObject();
        //private int number; // ����
        //private int shape; // ����

        //public void setcard(int num, int b) // ���ڿ� ������ ����
        //{
        //    number = num;
        //    shape = b;
        //}
        //public void print() // ���ڿ� ������ ���
        //{
        //    Debug.Log(number + " " + shape);
        //}
    }


}
