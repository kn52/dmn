package Day43;

public class SubarrayWithGivenSum {

	public static void main(String[] args) {
		int[] ans = solve(new int[] { 1, 2, 3, 4, 5 }, 5);
		System.out.println(ans);
	}
	public static int[] solve(int[] A, int B) {
        int N = A.length;
        if (N == 0) {
            return new int[]{-1};
        }
        if (N == 1 && A[0] != B) {
            return new int[]{ -1};
        }
        int L = 0;
        int R = 0;
        int sum = A[0];
        
        while (R < N && L < N) {
            if (sum == B) {
                break;
            }
            else if (sum < B) {
                R++;
                if (R < N) {
                    sum +=A[R];
                }
            }
            else {
                sum -= A[L];
                L++;
            }
        }
        if (R < N && L < N) {
            int size = R - L + 1;
            int ind = 0;
            int[] ans=new int[size];
            for(int x=L;x<=R;x++){
                ans[ind]=A[x];
                ind++;  
            }
            return ans;
        }
        return new int[] {-1};
        
    }
}
