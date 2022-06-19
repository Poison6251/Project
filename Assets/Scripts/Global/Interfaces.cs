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
        //private int number; // 숫자
        //private int shape; // 문양

        //public void setcard(int num, int b) // 숫자와 문양을 저장
        //{
        //    number = num;
        //    shape = b;
        //}
        //public void print() // 숫자와 문양을 출력
        //{
        //    Debug.Log(number + " " + shape);
        //}
    }


}
