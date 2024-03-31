package Day71;

import java.util.*;

public class TopologicalSort {

	public static void main(String[] args) {
		// TODO Auto-generated method stub

	}
	
	public ArrayList<Integer> solve(int A, ArrayList<ArrayList<Integer>> B) {

        ArrayList<ArrayList<Integer>> graph = new ArrayList<>();
        for(int i = 0 ; i < A+1 ; i++){
            graph.add(new ArrayList<>());
        }

        for(int i=0 ; i < B.size() ; i++){
            int u = B.get(i).get(0);
            int v = B.get(i).get(1);
            graph.get(u).add(v);
        }

        int[] inDegree = new int[A+1];
        for(int i=1; i < A+1 ; i++){
            ArrayList<Integer> list = graph.get(i);
            for (int j = 0; j < list.size(); j++) {
                int nbr = list.get(j);
                inDegree[nbr]++;
            }
        }

       PriorityQueue<Integer> q = new PriorityQueue<>();  
       for(int i=1 ; i < A+1 ; i++){
           if(inDegree[i] == 0){
                   q.add(i);
           }
       }

   
      ArrayList<Integer> ans = new ArrayList<>();
      
      while (q.size()!=0) {
            int rem = q.remove();
            ans.add(rem);
            ArrayList<Integer> neigh = graph.get(rem);
            for (int j = 0; j < neigh.size(); j++) {
                int nbr = neigh.get(j);
                inDegree[nbr]--;

                if (inDegree[nbr] == 0) {
                    q.add(nbr);
                }
            }
        }
       return ans;
    }

}
