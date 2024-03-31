package Day71;

import java.util.*;

public class PossibilityOfFinishing {

	public static void main(String[] args) {
		// TODO Auto-generated method stub

	}

	public int solve(int A, int[] B, int[] C) {
        List<Integer>[] adj = new ArrayList[A + 1];
        int[] indegree = new int[A + 1];
        boolean[] vis = new boolean[A + 1];

        for (int i = 1; i <= A; i++) {
            adj[i] = new ArrayList<>();
        }

        for (int i = 0; i < B.length; i++) {
            adj[B[i]].add(C[i]);
            indegree[C[i]]++;
        }

        Queue<Integer> q = new LinkedList<>();
        int count = 0;

        for (int i = 1; i <= A; i++) {
            if (indegree[i] == 0) {
                q.add(i);
                vis[i] = true;
                count++;
            }
        }

        while (!q.isEmpty()) {
            int node = q.poll();
            List<Integer> ans = adj[node];
            for (int k : ans) {
                if (!vis[k]) {
                    indegree[k]--;
                    if (indegree[k] == 0) {
                        vis[k] = true;
                        q.add(k);
                        count++;
                    }
                }
            }
        }

        if (count == A) return 1;

        return 0; 
    }
}
