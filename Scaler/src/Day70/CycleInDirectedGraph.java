package Day70;

import java.util.*;

public class CycleInDirectedGraph {

	public static void main(String[] args) {
		// TODO Auto-generated method stub

	}
	 public int solve(int A, ArrayList<ArrayList<Integer>> B) {
	        ArrayList<Integer> AdjList[] = new ArrayList[A+1];
	        for (int i=0; i<=A; i++) {
	            AdjList[i] = new ArrayList<>();
	        }
	        for(final ArrayList<Integer> edge : B) {
	            AdjList[edge.get(0)].add(edge.get(1));
	        }
	        boolean vis[] = new boolean[A+1], path[] = new boolean[A+1];
	        for(int i=1; i<=A; i++) {
	            if(vis[i] == false && dfs(AdjList, i, vis, path) == true) {
	                return 1;
	            }
	        }
	        return 0;
	    }

	    boolean dfs(ArrayList<Integer> AdjList[], int node, boolean vis[], boolean path[]) {
	        if(path[node] == true) {
	            return true;
	        }
	        vis[node] = true;
	        path[node] = true;
	        for(final int child : AdjList[node]) {
	            if(dfs(AdjList, child, vis, path) == true) {
	                return true;
	            }
	        }
	        path[node] = false;
	        return false;
	    }

}
