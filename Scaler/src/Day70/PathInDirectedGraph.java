package Day70;

import java.util.*;

public class PathInDirectedGraph {

	public static void main(String[] args) {
		// TODO Auto-generated method stub

	}
	
	boolean[] bool;

    public int solve(int A, int[][] B) {
        ArrayList<Integer>[] adl=AdjaList(A,B);
        bool=new boolean[A+1];
        Arrays.fill(bool,false);
        dfs(adl,1);
        if(bool[A]) return 1;
        else return 0;
    }

    public void dfs(ArrayList<Integer>[] adl,int node){
        bool[node]=true;
        for(int i=0;i<adl[node].size();i++){
            if(bool[adl[node].get(i)]== false){
                dfs(adl, adl[node].get(i));
            }
        }
    }

    public ArrayList<Integer> [] AdjaList(int A, int[][] B){
        ArrayList<Integer>[] al=new ArrayList[A+1];
        for(int i=0;i<al.length;i++){
            ArrayList<Integer> arlt=new ArrayList<>();
            al[i]=arlt; 
        }

        for(int i=0;i<B.length;i++){
            al[B[i][0]].add(B[i][1]);
        }

        return al;
    }

}
