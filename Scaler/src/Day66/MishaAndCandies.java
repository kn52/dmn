package Day66;

import java.util.*;

public class MishaAndCandies {

	public static void main(String[] args) {
		// TODO Auto-generated method stub

	}
	
	class pair {
        int index;
        int candies;
        Pair(int i, int c) {
            index = i;
            candies = c;
        }
    }
    public int solve(int[] A, int B) {
        int N = A.length;
        PriorityQueue<Pair> pq = new PriorityQueue<>();
        for (int i = 0; i < N; i++) {
            if (A[i] <= B) {
                pq.add(new pair(i, A[i]))
            }
        }
        int ans = 0;
        while(!pq.isEmpty()) {
            Pair p = pq.poll();
            if (A[p.index] > B) {
                continue;
            }
            int cal = 0;
            if (p.candies%2 == 0) {
                cal = p.candies/2;
            }
            else {
                cal = Math.floor(p.candies/2);
            }
            int remcal = p.candies - cal;
            ans += cal;
            
            calind = p.index + 1;
            if (calind == N) {
                calind = 0;
            }
            
            A[p.index] = 0;
            A[calind] += remcal;
        }
    }

}
