package Day60;

import java.util.*;

public class MinHeap {

	public static void main(String[] args) {
		// TODO Auto-generated method stub

	}
	public static ArrayList<Integer> solve(ArrayList<ArrayList<Integer>> A) {
        PriorityQueue<Integer> heap = new PriorityQueue<>();
       ArrayList<Integer> oper = new ArrayList<>();
       for(int i=0;i<A.size();i++){
           int P=A.get(i).get(0), Q=A.get(i).get(1);
         if(heap.size()==0 && P==1 && Q==-1){
             oper.add(-1);
         }
         else if(P==1 && Q==-1){
             oper.add(heap.remove());
         }
         else{
             heap.add(Q);
         }
       }
       return oper;
   }

}
