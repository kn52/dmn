package Day62;

import java.util.*;

public class FinishMaximumJob {

	public static void main(String[] args) {
		// TODO Auto-generated method stub

	}
	
	public int solve(int[] A, int[] B) {
        int[][] jobs = new int[A.length][2];
        for (int i = 0; i < A.length; i++) {
            jobs[i][0] = A[i];
            jobs[i][1] = B[i];
        }
        Arrays.sort(jobs, (a, b) -> Integer.compare(a[1], b[1]));
        int ans = 1;
        int endTime = jobs[0][1];
        for (int i = 1; i < jobs.length; i++) {
            if (jobs[i][0] >= endTime) {
                ans++;
                endTime = jobs[i][1];
            }
        }
        return ans;
    }
}
